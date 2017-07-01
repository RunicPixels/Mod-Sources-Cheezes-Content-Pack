using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class UltraVaporizer : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BulletHighVelocity);
            projectile.width = 12;
            projectile.height = 12;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 500;
            projectile.scale = 1f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.BulletHighVelocity;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultra Vaporizer");
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 1f, 1f, 1f);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(1) == 0)
            {
                int num1 = Dust.NewDust(projectile.position,projectile.width,projectile.height, 63,projectile.velocity.X,projectile.velocity.Y, 255, default(Color), 1.6f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.0f;
            }
            if (Main.rand.Next(1) == 0)
            {
                int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("WhiteLightCircle"), projectile.velocity.X, projectile.velocity.Y);
                Main.dust[num5].velocity *= 0.1f;
                Main.dust[num5].scale = 1.3f;
            }
            if (Main.rand.Next(1) == 0)
            {
                int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 20, projectile.velocity.X, projectile.velocity.Y);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity *= 0.15f;
                Main.dust[num2].scale = 1.2f;
            }
            if (Main.rand.Next(1) == 0)
            {
                int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X, projectile.velocity.Y);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity *= 0.1f;
                Main.dust[num2].scale = 1.2f;
            }
            if (Main.rand.Next(1) == 0)
            {
                int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("WhiteLightCircle"), projectile.velocity.X, projectile.velocity.Y);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity *= 0f;
                Main.dust[num2].scale = 1.6f;
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
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 132, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 0.5f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.1f;
            }
            for (int k = 0; k < 40; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 63, Main.rand.Next(5) - 2.5f, Main.rand.Next(300));
            }
            for (int k = 0; k < 5; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, Main.rand.Next(1) - 0.5f, Main.rand.Next(1) - 0.5f);
            }
            for (int k = 0; k < 5; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, Main.rand.Next(1) - 0.5f, Main.rand.Next(1) - 0.5f);
            }
            for (int k = 0; k < 10; k++)
            {
                int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 20, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 2f);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num2].type = 127;
                }
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity *= 0.3f;
            }
            int num4 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X / 100, projectile.velocity.Y / 100, ProjectileID.VortexBeaterRocket, (int)((float)projectile.damage * 0.5f), projectile.knockBack, projectile.owner);
            Main.projectile[num4].penetrate = 5;
            Main.projectile[num4].width = 80;
            Main.projectile[num4].height = 80;
            Main.projectile[num4].timeLeft = 20;
            Main.projectile[num4].alpha = 255;
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
        }
    }
}