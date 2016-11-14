using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class BlitzCannon : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BulletHighVelocity);
            projectile.name = "Blitz Shot";
            projectile.width = 15;
            projectile.height = 15;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 50;
            projectile.scale = 1f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.BulletHighVelocity;
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.2f, 0.7f, 1f);
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(4) == 0)
            {
                int num1 = Dust.NewDust(projectile.position,projectile.width,projectile.height,DustID.Electric,projectile.velocity.X,projectile.velocity.Y, 255, default(Color), 0.5f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.1f;
            }
            if (Main.rand.Next(2) == 0)
            {
                int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("ShortSparkle"), projectile.velocity.X, projectile.velocity.Y);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity *= 0.1f;
                Main.dust[num2].scale = 1.3f;
            }
            if (Main.rand.Next(2) == 0)
            {
                int num3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, projectile.velocity.X, projectile.velocity.Y);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].velocity *= 0.1f;
                Main.dust[num3].scale = 1.5f;
            }
            if (Main.rand.Next(1) == 0)
            {
                int num3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 2f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].velocity *= 0.1f;
            }
            if (Main.rand.Next(2) == 0)
            {
                int num4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, projectile.velocity.X, projectile.velocity.Y);
                Main.dust[num4].velocity *= 0.1f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 10; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Electric, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 0.5f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.1f;
            }
            for (int k = 0; k < 10; k++)
            {
                int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 2f);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num2].type = 127;
                }
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity *= 0.3f;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }
    }
}