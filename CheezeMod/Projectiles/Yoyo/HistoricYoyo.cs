using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Yoyo
{
    public class HistoricYoyo : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.TheEyeOfCthulhu);
            projectile.name = "Historic Yoyo";
            projectile.penetrate = -1;
            projectile.width = 28;
            projectile.height = 32;
            projectile.scale = 1.1f;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.timeLeft = 320;
        }
        public override void AI()
        {
            base.AI();
            projectile.velocity *= 1.03f;
            bool flag = Collision.LavaCollision(projectile.position, projectile.width, projectile.height);
            if (projectile.owner == Main.myPlayer)
            {
                projectile.localAI[0] += 1f;
                if (flag)
                {
                    projectile.localAI[0] += (float)Main.rand.Next(10, 31) * 0.5f;
                }
                float num = projectile.localAI[0] / 90f;
                num /= (1f + Main.player[projectile.owner].meleeSpeed) / 1f;
                if (num > 5f)
                {
                    projectile.ai[0] = -1f;
                }
            }
            Lighting.AddLight((int)projectile.Center.X / 16, (int)projectile.Center.Y / 16, 0.3f, 0.5f, 0.3f);
        }
    }
}