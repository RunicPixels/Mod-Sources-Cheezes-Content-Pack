using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod
{
	public class CheezePlayer : ModPlayer
	{
		public bool starlit = false;
        public bool flyffhistoric = false;
        public bool flyffangelic = false;
        public bool angelsBane = false;
        public bool superAngel = false;
        public bool downfall = false;
        public bool agentMinion = false;
        public bool agentDreadMinion = false;
        public bool agentMegaDreadMinion = false;
        public bool agentUltraDreadMinion = false;
        public float critMultiplier = 1.0f; // Base crit multiplier. Critical damage will be damage * this number + damage type modifier.
        public float meleeCritMultiplier = 0.0f; // Melee Crit Multiplier, percentage that will be added onto the critical damage.
        public float rangedCritMultiplier = 0.0f; // Ranged Crit Multiplier, percentage that will be added onto the critical damage.
        public float magicCritMultiplier = 0.0f; // Magic Crit Multiplier, percentage that will be added onto the critical damage.
        public float thrownCritMultiplier = 0.0f; // Thrown Crit Multiplier, percentage that will be added onto the critical damage.
                                                  //public float castingTime = 0.9f;

        //private bool didAlterUseTime = false;
        //private bool didAlterUseAnimation = false;
        //private bool didAlterReUse = false;

        public override void ResetEffects() // Resets effects back to normal after each cast, helps effects to go off when needed and prevents them from stacking infinite times.
        {
            this.starlit = false;
            this.flyffhistoric = false;
            this.flyffangelic = false;
            this.downfall = false;
            this.angelsBane = false;
            this.superAngel = false;
            this.agentMinion = false;
            this.agentDreadMinion = false;
            this.agentMegaDreadMinion = false;
            this.agentUltraDreadMinion = false;
            this.critMultiplier = 1.00f;
            this.meleeCritMultiplier = 0.0f;
            this.rangedCritMultiplier = 0.0f;
            this.magicCritMultiplier = 0.0f;
            this.thrownCritMultiplier = 0.0f;
            //this.castingTime = 0.9f;
        }

        public override void UpdateDead()
        {
            angelsBane = false;
            downfall = false;
            agentMinion = false;
            agentDreadMinion = false;
            agentMegaDreadMinion = false;
            agentUltraDreadMinion = false;
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (this.starlit == true)
            {
                player.AddBuff(mod.BuffType("Starlit"), 240);
            }
            if (this.flyffhistoric == true)
            {
                target.AddBuff(BuffID.DryadsWardDebuff, 60);
            }
            if (this.flyffangelic == true)
            {
                target.AddBuff(mod.BuffType("AngelsBane"), 600);
            }
        }
        public override void OnHitPvp(Item item, Player target, int damage, bool crit)
        {
            if (this.starlit == true)
            {
                player.AddBuff(mod.BuffType("Starlit"), 240);
            }
            if (this.flyffhistoric == true)
            {
                target.AddBuff(BuffID.DryadsWardDebuff, 60);
            }
            if (this.flyffangelic == true)
            {
                target.AddBuff(mod.BuffType("AngelsBane"), 600);
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (crit == true)
            {
                if(item.melee == true) // Melee Crit
                {
                    damage = (int)(damage * (critMultiplier + meleeCritMultiplier)); // Damage gets amplified by the crit multiplier.
                }
                else if (item.ranged == true) // Ranged Crit
                {
                    damage = (int)(damage * (critMultiplier + rangedCritMultiplier));
                }
                else if (item.magic == true) // Magic Crit
                {
                    damage = (int)(damage * (critMultiplier + magicCritMultiplier));
                }
                else if (item.thrown == true) // Thrown Crit
                {
                    damage = (int)(damage * (critMultiplier + thrownCritMultiplier));
                }
                else
                {
                    damage = (int)(damage * critMultiplier); // Damage gets amplified by the crit multiplier.
                }
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (proj.melee)
            {
                if (this.starlit == true)
                {
                    player.AddBuff(mod.BuffType("Starlit"), 200);
                }
            }
            if (this.flyffhistoric == true)
            {
                target.AddBuff(BuffID.DryadsWardDebuff, 450);
            }
            if (this.flyffangelic == true)
            {
                target.AddBuff(mod.BuffType("AngelsBane"), 450);
            }
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (crit == true)
            {
                if (proj.melee == true) // Melee Crit
                {
                    damage = (int)(damage * (critMultiplier + meleeCritMultiplier)); // Damage gets amplified by the crit multiplier.
                }
                else if (proj.ranged == true) // Ranged Crit
                {
                    damage = (int)(damage * (critMultiplier + rangedCritMultiplier));
                }
                else if (proj.magic == true) // Magic Crit
                {
                    damage = (int)(damage * (critMultiplier + magicCritMultiplier));
                }
                else if (proj.thrown == true) // Thrown Crit
                {
                    damage = (int)(damage * (critMultiplier + thrownCritMultiplier));
                }
                else
                {
                    damage = (int)(damage * critMultiplier); // Damage gets amplified by the crit multiplier.
                }
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (angelsBane) {
                if (player.position.Y <= Main.worldSurface * 1f)
                {
                    player.lifeRegen -= (Main.expertMode == true) ?  24 : 12;
                }
                else
                {
                    player.lifeRegen -= (Main.expertMode == true) ? 16 : 8;
                }
            }
        }

        public override void PreUpdateBuffs()
        {
            if (downfall)
            {
                player.velocity.Y -= 4;
            }
            /* if (player.inventory[player.selectedItem].magic == true)
             {
                 if (player.inventory[player.selectedItem].useAnimation >= 5 && !didAlterUseAnimation)
                 {
                     player.inventory[player.selectedItem].useAnimation = (int)(player.inventory[player.selectedItem].useAnimation * castingTime);
                     didAlterUseAnimation = true;
                 }
                 if (player.inventory[player.selectedItem].useTime >= 5 && !didAlterUseTime)
                 {
                     player.inventory[player.selectedItem].useTime = (int)(player.inventory[player.selectedItem].useTime * castingTime);
                     didAlterUseTime = true;
                 }
                 if (player.inventory[player.selectedItem].reuseDelay >= 1 && !didAlterReUse)
                 {
                     player.inventory[player.selectedItem].reuseDelay = (int)(player.inventory[player.selectedItem].reuseDelay * castingTime);
                     didAlterReUse = true;
                 }
             */
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (angelsBane)
            {
                //if (Main.rand.Next(3) == 0)
                // {
                //    Dust.NewDust(player.position, player.width, player.height, DustID.AncientLight, player.velocity.X * 0.3f, player.velocity.Y * 0.3f);
                // }
                r *= 2f;
                g *= 2f;
                b /= 2f;
                fullBright = true;
                if (player.position.Y <= Main.worldSurface)
                {
                    Dust.NewDust(player.position, player.width, player.height, mod.DustType("WhiteLightCircle"), player.velocity.X * 0.3f, player.velocity.Y * 0.3f);
                }
                else
                {
                    Dust.NewDust(player.position, player.width, player.height, mod.DustType("YellowLight"), player.velocity.X * 0.3f, player.velocity.Y * 0.3f);
                }
            }
            base.DrawEffects(drawInfo, ref r, ref g, ref b, ref a, ref fullBright);
        }

        public override void PostUpdateBuffs()
        {


            /*
            if (player.inventory[player.selectedItem].magic == true)
            {
                if (didAlterUseAnimation)
                {
                    player.inventory[player.selectedItem].useAnimation = (int)(player.inventory[player.selectedItem].useAnimation / castingTime);
                    didAlterUseAnimation = false;
                }
                if (didAlterUseTime)
                {
                    player.inventory[player.selectedItem].useTime = (int)(player.inventory[player.selectedItem].useTime / castingTime);
                    didAlterUseTime = false;
                }
                if (didAlterReUse)
                {
                    player.inventory[player.selectedItem].reuseDelay = (int)(player.inventory[player.selectedItem].reuseDelay / castingTime);
                    didAlterReUse = false;
                }
            }*/
        } 
    }
}
