using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Magic
{
    public class HealDown : ModProjectile
    {
        int bounceCount = 10;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WaterBolt);
            projectile.name = "Heal";
            projectile.width = 15;
            projectile.height = 15;
            projectile.magic = true;
            projectile.hostile = true;
            projectile.scale = 1f;
            projectile.timeLeft = 550;
            projectile.penetrate = 4;
            aiType = ProjectileID.WaterBolt;
        }  
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            damage = 0;
            base.OnHitPlayer(target, damage, crit);
        }
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            target.statLife += 5;
            target.HealEffect(5);
            base.ModifyHitPlayer(target, ref damage, ref crit);
        }
    }
}