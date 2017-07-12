using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Melee
{
    public class BladeOfKusanagi : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 162;
            projectile.height = 98;
            projectile.scale = 1f;
            projectile.timeLeft = 18;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.knockBack = 5f;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.ownerHitCheck = true;
            projectile.hide = false;
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BladeOfKusanagi");
            
        }

        public override void AI()
        {

            Player player = Main.player[projectile.owner];
            CheezePlayer cheezePlayer = ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer"));
            float rotationCorrection = 0;

            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true); // Basically a position that we can use to properly place our projectile.

            if (Main.myPlayer == projectile.owner) // Check if the local player is the owner of this projectile, if it is we update the rest.
            {
                if (player.channel && !player.noItems && !player.CCed) // So if the player is still using this weapon, since this weapon channels, we update it.
                {            
                    // Otherwise we KILL it (mwuahahaha). So basically destroy this projectile if the item is not being used.
                    Vector2 vector13 = Main.MouseWorld - vector; // Get the direction vector between the mouse position and the vector (vector was declared earlier, remember?)
                    vector13.Normalize(); // Normalize this vector since we're not in need of any large values, we just need to get the direction out of this.
                    if (vector13.HasNaNs()) // This check is basically used to check if the X value of the direction is 'Not a Number' (or a negative value in this case).
                    {
                        vector13 = Vector2.UnitX * (float)player.direction; // If it is, we
                    }
                    if (vector13.X != projectile.velocity.X || vector13.Y != projectile.velocity.Y) // If the vector13 value is actually changing something
                    {                                                                                                        // (so if the mouse or the player have been moved).
                        projectile.netUpdate = true; // Make sure it gets updated for everyone if you're in multiplayer.
                    }
                    projectile.velocity = vector13; // At last, set the velocity of this projectile to the 'vector13'. This is later used to set the rotation of the projectile correctly.
                }
            }
            else
            {
                projectile.Kill(); // Yeahh, so we destroy the projectile here if the item is not being used.
            }
            if (cheezePlayer.cutUp)
            {
                projectile.rotation = projectile.velocity.ToRotation() + rotationCorrection - 0.25f;// Assigns the rotation
            }
            else
            {
                projectile.rotation = projectile.velocity.ToRotation() + rotationCorrection + 0.25f; // Assigns the rotation
            }
            float projectileCenterX = (int)player.Center.X - (projectile.width / 2);
            float projectileCenterY = (int)player.Center.Y - (projectile.height / 2);

            float projectileOffsetX = projectileCenterX + 25;

            projectile.position.X = projectileCenterX + (projectileOffsetX - projectileCenterX) * (float)Math.Cos(projectile.rotation); // Assigns the x position
            projectile.position.Y = projectileCenterY + (projectileOffsetX - projectileCenterX) * (float)Math.Sin(projectile.rotation); // Assigns the y position

            player.itemTime = 6;// Hmm yeah, not really know what I should explain about this...
            player.itemAnimation = 6;

            player.ChangeDir(projectile.direction); // Makes sure that the owner of this projectile isfacing the same way that the projectile is (so that you don't get a situation in which
                                              // the projectile is on the left side of the player while the player is still facing the right.

        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            hitbox.Height = 150;
            hitbox.Y -= (hitbox.Height - projectile.height) / 2;
            hitbox.Width = 150;
            hitbox.X -= (hitbox.Width - projectile.width) /2;
        }

        //Allows you to draw things behind this projectile. Returns false to stop the game from drawing extras textures related to the projectile (for example, the chains for grappling hooks), useful if you're manually drawing the extras. Returns true by default.
        public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color lightColor)
        {
            Lighting.AddLight(projectile.Center, new Vector3(0.4f, 1f, .5f));
            Player player = Main.player[projectile.owner];
            Point playerCentre = player.Center.ToTileCoordinates();
            CheezePlayer cheezePlayer = ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer"));
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 160);
            }
            projectile.alpha = 25;
            if (cheezePlayer.cutUp == false) {
                if (projectile.timeLeft < 6)
                {
                    projectile.frame = 2;
                }
                else if (projectile.timeLeft < 12)
                {
                    projectile.frame = 1;
                }
                else
                {
                    projectile.frame = 0;
                }
            }
            else
            {
                if (projectile.timeLeft < 6)
                {
                    projectile.frame = 5;
                }
                else if (projectile.timeLeft < 12)
                {
                    projectile.frame = 4;
                }
                else
                {
                    projectile.frame = 3;
                }
            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            projectile.hide = true;
            Player player = Main.player[projectile.owner];
            Point playerCentre = player.Center.ToTileCoordinates();
            CheezePlayer cheezePlayer = ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer"));
            cheezePlayer.cutUp = !cheezePlayer.cutUp;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];
        }
    }
}