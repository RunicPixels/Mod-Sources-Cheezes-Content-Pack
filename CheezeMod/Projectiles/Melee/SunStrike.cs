
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Melee
{
    public class SunStrike : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.InfernoFriendlyBolt);
            projectile.name = "Sun Strike";
            projectile.melee = true;
            projectile.scale = 1f;
            projectile.height = 16;
            projectile.width = 16;
            projectile.penetrate = 2;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);
            projectile.width = 50;
            projectile.height = 50;
        }

        public override void AI()
        {
            bool waterFlag = Collision.WetCollision(projectile.position, projectile.width, projectile.height);
            if (waterFlag)
            {
                projectile.Kill();
            }
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 1f, 0.75f, 0f);
        }

        public override bool PreKill(int timeLeft)
        {
            projectile.type =  41;
            projectile.scale = 1f;
            return true;
        }
	}
}