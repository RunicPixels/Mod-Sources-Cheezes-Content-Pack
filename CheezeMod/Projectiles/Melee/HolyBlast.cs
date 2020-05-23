using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Melee
{
    public class HolyBlast : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.damage = 60;
            projectile.width = 32;
            projectile.height = 28;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.scale = 0.6f;
            projectile.penetrate = 3;
            projectile.timeLeft = 300;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Strike");
        }

        public override bool PreAI()
        {
            projectile.spriteDirection = projectile.direction;
            return base.PreAI();
        }
        
        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.75f, 1f, 0.5f);
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(8) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("ShortSparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            if (Main.rand.Next(8) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.GoldFlame, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int i = 0; i < 9; i++) { }
            {
                if (Main.rand.Next(2) == 0)
                {
                    int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("ShortSparkle"), projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 1f);
                    Main.dust[num1].noGravity = true;
                    Main.dust[num1].velocity *= 0.1f;
                }
                if (Main.rand.Next(3) == 0)
                {
                    int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.GoldFlame, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[num1].noGravity = true;
                    Main.dust[num1].velocity *= 0.2f;
                }
            }
        }

    public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];
            if (Main.rand.Next(10) == 0)
            {
                target.AddBuff(BuffID.CursedInferno, 180);
            }
            else if (Main.rand.Next(10) == 0)
            {
                target.AddBuff(BuffID.Ichor, 180);
            }
        }
    }
}