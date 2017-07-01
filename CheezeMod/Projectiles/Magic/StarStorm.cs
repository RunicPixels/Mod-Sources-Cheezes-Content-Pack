using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Magic
{
    public class StarStorm : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.scale = 0.7f;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 50;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star");
        }

        public override void AI()
        {

            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.8f, 0.8f, 0.4f);
            projectile.rotation += (float)projectile.direction * 0.15f;
            projectile.velocity.Y += projectile.ai[0];
            if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("ShortSparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("ShortSparkle"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 25);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            if (Main.rand.Next(3) == 0)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 25);
            }
            return false;
        }
    }
}