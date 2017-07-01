using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

//using ItemCustomizer;
using Terraria.ModLoader.IO;
using System.IO;
//using Terraria.Graphics.Shaders;
//vs collapse all Ctrl-M-O

namespace CheezeMod
{
    public class PlayerFX : ModPlayer
    {
        private const bool DEBUG_WEAPONHOLD = false;
        private const bool DEBUG_BOOMERANGS = false;
        private const bool DEBUG_PARRYFISTS = false;

        public bool weaponVisual = true;

        private bool wasDead; //used to check if player just revived
        public Vector2 localTempSpawn;//spawn used by tent

        public int weaponFrame;//frame of weapon...

        private int damageKnockbackThreshold;
        public int DamageKnockbackThreshold
        {
            get { return damageKnockbackThreshold; }
            set
            {
                if (value > damageKnockbackThreshold) damageKnockbackThreshold = value;
            }
        }

        private int frontDefence;
        public int FrontDefence
        {
            get { return frontDefence; }
            set
            {
                if (value > frontDefence) frontDefence = value;
            }
        }
        public bool frontNoKnockback;

        public int lastSelectedItem;
        public int itemSkillDelay;

        public int dashingSpecialAttack;
        public const int dashingSpecialAttackOnsoku = 1;

        public bool reflectingProjectiles;
        public int reflectingProjectileDelay;
        public bool CanReflectProjectiles
        { get { return reflectingProjectiles && reflectingProjectileDelay <= 0; } }

        public bool lunarRangeVisual;
        public bool lunarMagicVisual;
        public bool lunarThrowVisual;

        public int parryTime;
        public int parryTimeMax;
        public int parryActive;
        public bool IsParryActive { get { return parryTime >= parryActive && parryTime > 0; } }

        #region Utils
        public static void drawMagicCast(Player player, SpriteBatch spriteBatch, Color colour, int frame)
        {
            Texture2D textureCasting = Main.extraTexture[51];
            Vector2 origin = player.Bottom + new Vector2(0f, player.gfxOffY + 4f);
            if (player.gravDir < 0) origin.Y -= player.height + 8f;
            Rectangle rectangle = textureCasting.Frame(1, 4, 0, Math.Max(0, Math.Min(3, frame)));
            Vector2 origin2 = rectangle.Size() * new Vector2(0.5f, 1f);
            if (player.gravDir < 0) origin2.Y = 0f;
            spriteBatch.Draw(
                textureCasting, new Vector2((float)((int)(origin.X - Main.screenPosition.X)), (float)((int)(origin.Y - Main.screenPosition.Y))),
                new Rectangle?(rectangle), colour, 0f, origin2, 1f,
                player.gravDir >= 0f ? SpriteEffects.None : SpriteEffects.FlipVertically, 0f);
        }
        public static void modifyPlayerItemLocation(Player player, float X, float Y)
        {
            float cosRot = (float)Math.Cos(player.itemRotation);
            float sinRot = (float)Math.Sin(player.itemRotation);
            //Align
            player.itemLocation.X = player.itemLocation.X + (X * cosRot * player.direction) + (Y * sinRot * player.gravDir);
            player.itemLocation.Y = player.itemLocation.Y + (X * sinRot * player.direction) - (Y * cosRot * player.gravDir);
        }

        public static bool SameTeam(Player player1, Player player2)
        {
            // Always affects self
            if (player1.whoAmI == player2.whoAmI) return true;
            // If on a team, must be sharding a team
            if (player1.team > 0 && player1.team != player2.team) return false;
            // Not on same team during PVP
            if (player1.hostile && player2.hostile && (player1.team == 0 || player2.team == 0)) return false;
            // Banner applies to all (See Nebula Buff mechanics)
            return true;
        }

        public static void ItemFlashFX(Player player, int dustType = 45)
        {
            Main.PlaySound(25, -1, -1, 1);
            for (int i = 0; i < 5; i++)
            {
                int d = Dust.NewDust(
                    player.position, player.width, player.height, dustType, 0f, 0f, 255,
                    default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
                Main.dust[d].noLight = true;
                Main.dust[d].noGravity = true;
                Main.dust[d].velocity *= 0.5f;
            }
        }
        #endregion

        public override void OnEnterWorld(Player player)
        {
            lastSelectedItem = 0;

            itemSkillDelay = 0;
            dashingSpecialAttack = 0;

            localTempSpawn = new Vector2();

            parryTime = 0;
            parryTimeMax = 0;
            parryActive = 0;

            // Update visuals
            //WeaponOut.NetUpdateWeaponVisual(mod, this);
        }

        public override void ResetEffects()
        {
            damageKnockbackThreshold = 0;
            frontDefence = 0;
            frontNoKnockback = false;

            if (player.velocity.Y == 0 && player.itemTime == 0)
            {
                if (dashingSpecialAttack != 0)
                {
                    //bleep
                    ItemFlashFX(player, 175);
                }
                // Restore special dashing if grounded
                dashingSpecialAttack = 0;
            }

            // Manage item skills
            if (player.selectedItem != lastSelectedItem)
            {
                lastSelectedItem = player.selectedItem;

                itemSkillDelay = 0;
                //Main.NewText(String.Concat(player.selectedItem, " / ", player.oldSelectItem));
            }

            // Reset visuals
            lunarRangeVisual = false;
            lunarMagicVisual = false;
            lunarThrowVisual = false;

            // Handle reflecting timer
            reflectingProjectiles = false;
            if (reflectingProjectileDelay > 0) reflectingProjectileDelay = Math.Max(0, reflectingProjectileDelay - 1);
        }

        #region Save and Load
        public override TagCompound Save()
        {
            return new TagCompound
            {
                { "weaponVisual", weaponVisual }
            };
        }
        public override void Load(TagCompound tag)
        {
            weaponVisual = tag.GetBool("weaponVisual");
        }
        #endregion

        private bool ItemCheckParry()
        {
            if (parryTime != 0)
            {
                if (parryTime == parryTimeMax)
                {
                    Main.PlaySound(2, player.Center, 32);
                }

                if (DEBUG_PARRYFISTS) Main.NewText(string.Concat("Parrying: ", parryTime, "/", parryActive, "/", parryTimeMax));

                if (parryTime > 0)
                {
                    player.itemAnimation = 1; // prevent switching
                    parryTime--;

                    if (parryTime == 0)
                    {
                        player.itemAnimation = 0; // release lock
                        parryTime = 0;
                        parryTimeMax = 0;
                        parryActive = 0;
                    }

                    return true;
                }

                // Cooldown
                if (parryTime < 0)
                {
                    parryTime++;

                    if (parryTime == 0)
                    {
                        ItemFlashFX(player);
                        parryTime = 0;
                        parryTimeMax = 0;
                        parryActive = 0;
                    }

                    return false;
                }
            }
            return false;
        }

        public override void PostUpdateRunSpeeds()
        {
            CustomDashMovement();
        }


        #region Dash

        public int weaponDash = 0;
        private void CustomDashMovement()
        {
            // dash = player equipped dash type
            // dashTime = timeWindow for double tap
            // dashDelay = -1 during active, counts down to 0 after dash ends (30 for SoC, 20 for tabi)
            // eocDash = SoC active frame time, 15 until dash ends, then count down (still active during deccel)
            // eocHit = registers the hit NPC for 8 frames

            // Reset here because reasons.
            if (player.pulley || player.grapCount > 0) weaponDash = 0;
            if (weaponDash > 0)
            {
                if (player.dashDelay == 0)
                {
                    #region Dash Stats
                    /*
                     * Normal: 3
                     * Aglet/Anklet: 3.15, 3.3
                     * Hermes: 6
                     * Lightning: 6.75
                     * Fishron Air: 8
                     * Solar Wings: 9
                     */
                    float dashSpeed = 14.5f;
                    switch (weaponDash)
                    {
                        case 1: // Guardian Knuckle
                            dashSpeed = 10f;
                            break;
                        case 2: // One Punch Glove
                            dashSpeed = 15f;
                            break;
                        case 3: // Boxing Gloves
                            dashSpeed = 12f;
                            Gore g;
                            if (player.velocity.Y == 0f)
                            {
                                g = Main.gore[Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 24f, player.position.Y + (float)(player.height / 2) - 4f), default(Vector2), Main.rand.Next(61, 64), 1f)];
                            }
                            else
                            {
                                g = Main.gore[Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 24f, player.position.Y + (float)(player.height / 2) - 14f), default(Vector2), Main.rand.Next(61, 64), 1f)];
                            }
                            g.velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
                            g.velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
                            g.velocity *= 0.4f;
                            break;
                        case 4: // Spiked Gauntlets
                            dashSpeed = 13f;
                            break;
                        case 5: // Apocafist
                            dashSpeed = 13f;
                            break;
                    }
                    #endregion

                    #region Set Dash speed

                    // Set initial dash speed
                    float direction = 0;
                    /*
                    if (player.controlLeft && !player.controlRight) direction = -1;
                    if (player.controlRight && !player.controlLeft) direction = 1;
                    if (direction == 0)
                    {
                        direction = player.direction;
                    }
                    */
                    direction = player.direction;
                    player.velocity.X = dashSpeed * direction;
                    Point point3 = (player.Center + new Vector2((float)(player.direction * player.width / 2 + 2), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
                    Point point4 = (player.Center + new Vector2((float)(player.direction * player.width / 2 + 2), 0f)).ToTileCoordinates();
                    if (WorldGen.SolidOrSlopedTile(point3.X, point3.Y) || WorldGen.SolidOrSlopedTile(point4.X, point4.Y))
                    {
                        player.velocity.X = player.velocity.X / 2f;
                    }
                    player.dashDelay = -1;

                    CheezeMod.NetUpdateDash(mod, this);

                    #endregion
                }

                // Apply movement during dash, delay is managed already in DashMovement()
                float maxAccRunSpeed = Math.Max(player.accRunSpeed, player.maxRunSpeed);
                if (player.dashDelay < 0)
                {
                    player.dash = 0; // Prevent vanilla dash movement

                    #region Dash Stats
                    float dashMaxSpeedThreshold = 12f;
                    float dashMaxFriction = 0.992f;
                    float dashMinFriction = 0.96f;
                    int dashSetDelay = 30; // normally 20 but given that his ends sooner...
                    switch (weaponDash)
                    {
                        case 1: // Normal short-ish dash
                            dashMaxSpeedThreshold = 8f;
                            dashMaxFriction = 0.98f;
                            dashMinFriction = 0.94f;
                            for (int i = 0; i < 3; i++)
                            {
                                Dust d = Main.dust[Dust.NewDust(player.position, player.width, player.height,
                                  mod.DustType("BlueLight"), 0, 0, 100, default(Color), 1.8f)];
                                d.velocity = d.velocity * 0.5f + player.velocity * -0.4f;
                                d.noGravity = true;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                            }
                            break;
                        case 2: // Super quick ~12 tile dash
                            dashMaxSpeedThreshold = 500f;
                            dashMaxFriction = 0.995f;
                            dashMinFriction = 0.99f;
                            for (int i = 0; i < 3; i++)
                            {
                                Dust d = Main.dust[Dust.NewDust(player.position, player.width, player.height,
                                  mod.DustType("Sparkle"), 0, 0, 100, default(Color), 1.8f)];
                                d.velocity = d.velocity * 0.5f + player.velocity * -0.4f;
                                d.noGravity = true;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                            }
                            break;
                        case 3: // Boxing Gloves ~ 4.5 tile step
                            dashMaxSpeedThreshold = 3f;
                            dashMaxFriction = 0.8f;
                            for (int j = 0; j < 2; j++)
                            {
                                Dust d;
                                if (player.velocity.Y == 0f)
                                {
                                    d = Main.dust[Dust.NewDust(new Vector2(player.position.X, player.position.Y + (float)player.height - 4f), player.width, 8, 31, 0f, 0f, 100, default(Color), 1.4f)];
                                }
                                else
                                {
                                    d = Main.dust[Dust.NewDust(new Vector2(player.position.X, player.position.Y + (float)(player.height / 2) - 8f), player.width, 16, 31, 0f, 0f, 100, default(Color), 1.4f)];
                                }
                                d.velocity *= 0.1f;
                                d.scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                            }
                            break;
                        case 4: // Spiked Gauntlets
                            dashMaxSpeedThreshold = 10f;
                            dashMaxFriction = 0.985f;
                            dashMinFriction = 0.95f;
                            for (int k = 0; k < 2; k++)
                            {
                                Dust d;
                                if (player.velocity.Y == 0f)
                                {
                                    d = Main.dust[Dust.NewDust(new Vector2(player.position.X, player.position.Y + (float)player.height - 8f), player.width, 16, 39, player.velocity.X, 0f, 0, default(Color), 1.4f)];
                                }
                                else
                                {
                                    d = Main.dust[Dust.NewDust(new Vector2(player.position.X, player.position.Y + (float)(player.height / 2) - 10f), player.width, 20, 40, player.velocity.X, 0f, 0, default(Color), 1.4f)];
                                }
                                d.velocity *= 0.1f;
                                d.scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
                                d.noGravity = true;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                            }
                            break;
                        case 5: // Long range
                            dashMaxSpeedThreshold = 7f;
                            dashMaxFriction = 0.99f;
                            dashMinFriction = 0.8f;
                            for (int i = 0; i < 4; i++)
                            {
                                Dust d = Main.dust[Dust.NewDust(player.position, player.width, player.height,
                                    DustID.Fire, 0, 0, 100, default(Color), 2f)];
                                d.velocity = d.velocity * 0.5f + player.velocity * -0.4f;
                                d.noGravity = true;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                                d = Main.dust[Dust.NewDust(player.position, player.width, player.height,
                                    DustID.Smoke, 0, 0, 100, default(Color), 0.4f)];
                                d.fadeIn = 0.7f;
                                d.velocity = d.velocity * 0.1f + player.velocity * -0.2f;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                            }
                            break;
                        // 10 - 19 ARE SPECIAL GAME REFERENCES
                        case 10: // Long range // SAXTON HALE'S FIST
                            dashMaxSpeedThreshold = 7f;
                            dashMaxFriction = 0.99f;
                            dashMinFriction = 0.8f;
                            for (int i = 0; i < 4; i++)
                            {
                                Dust d = Main.dust[Dust.NewDust(player.position, player.width, player.height,
                                    DustID.Smoke, 0, 0, 100, default(Color), 2f)];
                                d.velocity = d.velocity * 0.5f + player.velocity * -0.4f;
                                d.noGravity = true;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                                d = Main.dust[Dust.NewDust(player.position, player.width, player.height,
                                    DustID.Smoke, 0, 0, 100, default(Color), 0.4f)];
                                d.fadeIn = 0.7f;
                                d.velocity = d.velocity * 0.1f + player.velocity * -0.2f;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                                
                            }
                            for (int i = 0; i < 4; i++)
                            {
                                Dust d = Main.dust[Dust.NewDust(player.position, player.width, player.height,
                                    DustID.Gold, 0, 0, 100, default(Color), 2f)];
                                d.velocity = d.velocity * 0.5f + player.velocity * -0.4f;
                                d.noGravity = true;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                                d = Main.dust[Dust.NewDust(player.position, player.width, player.height,
                                    DustID.Smoke, 0, 0, 100, default(Color), 0.4f)];
                                d.fadeIn = 0.7f;
                                d.velocity = d.velocity * 0.1f + player.velocity * -0.2f;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                            }
                            break;
                        // 20 - 29 ARE RELATED TO FLYFF
                        case 20: // Normal short-ish dash // GUARDIAN KNUCKLE
                            dashMaxSpeedThreshold = 8f;
                            dashMaxFriction = 0.98f;
                            dashMinFriction = 0.94f;
                            for (int i = 0; i < 3; i++)
                            {
                                Dust d = Main.dust[Dust.NewDust(player.position, player.width, player.height,
                                  mod.DustType("BlueLight"), 0, 0, 100, default(Color), 1.8f)];
                                d.velocity = d.velocity * 0.5f + player.velocity * -0.4f;
                                d.noGravity = true;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                            }
                            break;
                        case 21: // Normal short-ish dash  // HISTORIC KNUCKLE
                            dashMaxSpeedThreshold = 10f;
                            dashMaxFriction = 0.98f;
                            dashMinFriction = 0.94f;
                            for (int i = 0; i < 3; i++)
                            {
                                Dust d = Main.dust[Dust.NewDust(player.position, player.width, player.height,
                                  107, 0, 0, 100, default(Color), 1.8f)];
                                d.velocity = d.velocity * 0.5f + player.velocity * -0.4f;
                                d.noGravity = true;
                                d.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                            }
                            break;
                    }
                    #endregion

                    #region Modify dash speeds

                    player.vortexStealthActive = false;
                    if (player.velocity.X > dashMaxSpeedThreshold || player.velocity.X < -dashMaxSpeedThreshold)
                    {
                        player.velocity.X = player.velocity.X * dashMaxFriction;
                    }
                    else if (player.velocity.X > maxAccRunSpeed || player.velocity.X < -maxAccRunSpeed)
                    {
                        player.velocity.X = player.velocity.X * dashMinFriction;
                    }
                    else
                    {
                        player.dashDelay = dashSetDelay;
                        if (player.velocity.X < 0f)
                        {
                            player.velocity.X = -maxAccRunSpeed;
                        }
                        else if (player.velocity.X > 0f)
                        {
                            player.velocity.X = maxAccRunSpeed;
                        }
                    }

                    #endregion
                }
            }

            if (player.dashDelay == 1)
            {
                weaponDash = 0;
            }
        }

        #endregion

        public override void PostUpdate()
        {
            manageBodyFrame();
            tentScript();
            setHandToFistWeapon();
        }

        private void manageBodyFrame()
        {
            if (Main.netMode == 2) return; // Oh yeah, server calls this so don't pls

            if (parryTime > 0)
            {
                Items.Weapons.UseStyles.FistStyle.ParryBodyFrame(this);
                return;
            }

            //change idle pose for player using a heavy weapon
            //copypasting from drawPlayerItem
            Item heldItem = player.inventory[player.selectedItem];
            if (heldItem == null || heldItem.type == 0 || heldItem.holdStyle != 0) return; //no item so nothing to show
            Texture2D weaponTex = weaponTex = Main.itemTexture[heldItem.type];
            if (weaponTex == null) return; //no texture to item so ignore too
            float itemWidth = weaponTex.Width * heldItem.scale;
            float itemHeight = weaponTex.Height * heldItem.scale;
            float larger = Math.Max(itemWidth, itemHeight);
            int playerBodyFrameNum = player.bodyFrame.Y / player.bodyFrame.Height;
            if (heldItem.useStyle == 5
                && weaponTex.Width >= weaponTex.Height * 1.2f
                && (!heldItem.noUseGraphic || !heldItem.melee)
                && larger >= 45
                && (
                weaponVisual
                ) //toggle with accessory1 visibility, or forceshow is on
            )
            {
                if (playerBodyFrameNum == 0) player.bodyFrame.Y = 10 * player.bodyFrame.Height;
            }
        }
        private void tentScript()
        {
            if (wasDead && !player.dead)
            {
                if (localTempSpawn != default(Vector2)) checkTemporarySpawn();
                wasDead = false;
            }
            if (player.dead)
            {
                wasDead = true;
            }
        }
        private void checkTemporarySpawn()
        {
            if (player.whoAmI == Main.myPlayer)
            {
                //int dID = Dust.NewDust(new Vector2((float)(localTempSpawn.X * 16), (float)(localTempSpawn.Y * 16)), 16, 16, 44, 0f, 0f, 0, default(Color), 4f);
                //Main.dust[dID].velocity *= 0f;

                if ((int)Main.tile[(int)localTempSpawn.X, (int)localTempSpawn.Y].type != mod.TileType("CampTent"))
                {
                    Main.NewText("Temporary spawn was removed, returned to normal spawn", 255, 240, 20, false);
                    localTempSpawn = default(Vector2);
                    return;
                }
                Main.BlackFadeIn = 255;
                Main.renderNow = true;

                player.position.X = (float)(localTempSpawn.X * 16 + 8 - player.width / 2);
                player.position.Y = (float)((localTempSpawn.Y + 1) * 16 - player.height);
                player.fallStart = (int)(player.position.Y / 16);

                Main.screenPosition.X = player.position.X + (float)(player.width / 2) - (float)(Main.screenWidth / 2);
                Main.screenPosition.Y = player.position.Y + (float)(player.height / 2) - (float)(Main.screenHeight / 2);
            }
        }

        #region Player Layers
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            setHandToFistWeapon();

            //MiscEffectsFront.visible = !player.dead;
            try
            {
                int heldItemStack = layers.IndexOf(PlayerLayer.HeldItem);
                int hairBackStack = layers.IndexOf(PlayerLayer.HairBack);
                int MiscEffectsFrontStack = layers.IndexOf(PlayerLayer.MiscEffectsFront);
            }
            catch { }
            //layers.Insert(MiscEffectsFrontStack, MiscEffectsFront);
        }
        #endregion
        /// <summary>
        /// We gonna handle all the weapon identification and calls here
        /// </summary>
        /// <param name="drawInfo"></param>
        /// <param name="drawOnBack"></param>

        private void setHandToFistWeapon()
        {
            if (player.HeldItem.useStyle == Items.Weapons.UseStyles.FistStyle.useStyle)
                {
                    if (player.HeldItem.handOnSlot > 0) player.handon = player.HeldItem.handOnSlot;
                    if (player.HeldItem.handOffSlot > 0) player.handoff = player.HeldItem.handOffSlot;
                }
        }

        /// <summary>
        /// Weak reference, must wrap in try catch exception becase won't catch FileNotFoundException
        /// </summary>
        /// <param name="drawInfo"></param>
        /// <param name="item"></param>
        /// <param name="shader"></param>

        #region Hurt && Parry Methods


        /// <summary>
        /// 
        /// </summary>
        /// <param name="damageSource"></param>
        /// <returns>True when attack is parried</returns>
        private bool ParryPreHurt(PlayerDeathReason damageSource)
        {
            // Caused by normal damage?
            if (damageSource.SourceNPCIndex >= 0 || damageSource.SourcePlayerIndex >= 0 || damageSource.SourceProjectileIndex >= 0)
            {
                // Stop this attack and parry with cooldown
                if (IsParryActive)
                {
                    player.itemAnimation = 0; //release item lock

                    int timeSet = parryActive;

                    //set cooldown to prevent spam
                    parryTime = timeSet * -3;
                    parryActive = 0;
                    parryTimeMax = 0;

                    // Strike the NPC away slightly
                    if (damageSource.SourceNPCIndex >= 0)
                    {
                        NPC npc = Main.npc[damageSource.SourceNPCIndex];
                        int hitDirection = player.direction;
                        float knockback = 4f;
                        if (npc.knockBackResist > 0)
                        {
                            knockback /= npc.knockBackResist;
                        }
                        npc.StrikeNPC(npc.defense, knockback, player.direction, false, false, false);
                        if (Main.netMode != 0)
                        {
                            NetMessage.SendData(28, -1, -1, null, npc.whoAmI, (float)npc.defense, (float)knockback, (float)hitDirection, 0, 0, 0);
                        }
                    }
                    else
                    {
                        Main.PlaySound(SoundID.NPCHit3, player.position);
                        if (damageSource.SourceProjectileIndex >= 0)
                        {
                            ProjFX.ReflectProjectilePlayer(
                                Main.projectile[damageSource.SourceProjectileIndex],
                                player,
                                this,
                                false);
                        }
                    }

                    // Add 5 sec parry buff and short invincibility
                    Items.Weapons.UseStyles.FistStyle.provideImmunity(player, 20);
                    player.AddBuff(mod.BuffType<Buffs.ParryActive>(), 300, false);

                    if (DEBUG_PARRYFISTS) Main.NewText(string.Concat("Parried! : ", parryTime, "/", parryActive, "/", parryTimeMax));
                    CheezeMod.NetUpdateParry(mod, this);
                    return true;
                }
            }
            return false;
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            ShieldBounceNPC(npc);
        }

        private void ShieldPreHurt(int damage, bool crit, int hitDirection)
        {
            if (DamageKnockbackThreshold > 0)
            {
                if (crit) damage *= 2;
                damage = (int)Main.CalculatePlayerDamage(damage, player.statDefense);
                //Main.NewText("Took damage: " + damage + " vs " + DamageKnockbackThreshold);
                if (Main.expertMode)
                { if (damage <= DamageKnockbackThreshold) player.noKnockback = true; }
                else
                { if (damage <= DamageKnockbackThreshold * Main.expertNPCDamage) player.noKnockback = true; }

            }

            if (player.direction != hitDirection)
            {
                if (FrontDefence > 0) player.statDefense += FrontDefence;
                //Main.NewText("DEF " + player.statDefense + " | " + FrontDefence);
                if (frontNoKnockback) player.noKnockback = true;
            }
        }
        private void ShieldBounceNPC(NPC npc)
        {
            //ignore if not facing
            if (player.direction == 1 && npc.Center.X < player.Center.X) return;
            if (player.direction == -1 && npc.Center.X > player.Center.X) return;

            //bump if not attacking
            if (player.whoAmI == Main.myPlayer && player.itemAnimation == 0
                && !player.immune && frontNoKnockback && !npc.dontTakeDamage)
            {
                int hitDamage = 1;
                float knockBack = (Math.Abs(player.velocity.X * 2) + 2f) / (0.2f + npc.knockBackResist); //sclaing knockback with kbr
                int hitDirection = player.direction;
                npc.StrikeNPC(hitDamage, (float)knockBack, hitDirection, false, false, false);
                if (Main.netMode != 0)
                {
                    NetMessage.SendData(28, -1, -1, null, npc.whoAmI, (float)hitDamage, (float)knockBack, (float)hitDirection, 0, 0, 0);
                }
            }
        }

        #endregion
    }
}