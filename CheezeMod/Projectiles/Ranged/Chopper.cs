using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class Chopper : ModProjectile
    {
        int maxBounces = 3;
        public override void SetDefaults()
        {
            projectile.name = "Chopper";
            projectile.width = 20;
            projectile.height = 20;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.timeLeft = 300;
            projectile.scale = 0.9f;
            projectile.penetrate = 4;
            aiType = ProjectileID.Shuriken;
        }

        public override void AI()
        {
            projectile.rotation += (float)projectile.direction * 0.4f;
            projectile.velocity.Y += 0.3f;
            projectile.velocity *= 0.995f;
            if (Main.rand.Next(2) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, projectile.velocity.X, projectile.velocity.Y);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.1f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            if (maxBounces > 0)
            {
                {
                    Bounce(oldVelocity);
                    maxBounces--;
                    Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
                }
            }
            else
            {
                projectile.Kill();
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            if (Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, ItemID.Shuriken);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 60, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f);
            }
        }
        public void Bounce(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y / 5 * 3;
            }
        }
    }
}