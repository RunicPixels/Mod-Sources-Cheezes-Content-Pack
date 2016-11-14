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
        public bool flyffhistoric = true;
        public float critMultiplier = 1.0f; // Base crit multiplier. Critical damage will be damage * this number.
        public float meleeCritMultiplier = 0.0f;
        public float rangedCritMultiplier = 0.0f;
        public float magicCritMultiplier = 0.0f;
        public float thrownCritMultiplier = 0.0f;

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
        }
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (crit == true)
            {
                if(item.melee == true)
                {
                    damage = (int)(damage * (critMultiplier + meleeCritMultiplier)); // Damage gets amplified by the crit multiplier.
                }
                else if (item.ranged == true)
                {
                    damage = (int)(damage * (critMultiplier + rangedCritMultiplier));
                }
                else if (item.magic == true)
                {
                    damage = (int)(damage * (critMultiplier + magicCritMultiplier));
                }
                else if (item.thrown == true)
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
                target.AddBuff(BuffID.DryadsWardDebuff, 60);
            }
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (crit == true)
            {
                if (proj.melee == true)
                {
                    damage = (int)(damage * (critMultiplier + meleeCritMultiplier)); // Damage gets amplified by the crit multiplier.
                }
                else if (proj.ranged == true)
                {
                    damage = (int)(damage * (critMultiplier + rangedCritMultiplier));
                }
                else if (proj.magic == true)
                {
                    damage = (int)(damage * (critMultiplier + magicCritMultiplier));
                }
                else if (proj.thrown == true)
                {
                    damage = (int)(damage * (critMultiplier + thrownCritMultiplier));
                }
                else
                {
                    damage = (int)(damage * critMultiplier); // Damage gets amplified by the crit multiplier.
                }
            }
        }
        public override void ResetEffects() // Resets effects back to normal after each cast, helps effects to go off when needed and prevents them from stacking infinite times.
        {
            this.starlit = false;
            this.flyffhistoric = false;
            this.critMultiplier = 1.00f;
            this.meleeCritMultiplier = 0.0f;
            this.rangedCritMultiplier = 0.0f;
            this.magicCritMultiplier = 0.0f;
            this.thrownCritMultiplier = 0.0f;
        }
    }
}
