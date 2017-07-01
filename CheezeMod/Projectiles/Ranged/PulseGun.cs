using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class PulseGun : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bullet);
            projectile.damage = 8;
            projectile.width = 8;
            projectile.height = 8;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 300;
            projectile.scale = 1f;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pulse Shot");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }
        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.1f, 0.3f, 0.6f);
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            for (int i = 0 ; i < 3; i++) { 
            int num1 = Dust.NewDust(projectile.position - projectile.velocity * Main.rand.NextFloat(), projectile.width, projectile.height, 135, projectile.velocity.X, projectile.velocity.Y);
            Main.dust[num1].noGravity = true;
            Main.dust[num1].velocity *= 0.1f + (Main.rand.NextFloat() * 0.4f);
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, projectile.velocity.X, projectile.velocity.Y);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.1f;
            }
            for (int k = 0; k < 2; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Electric, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 0.45f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.1f;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }
    }
}