using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Magic
{
    public class WindFieldBlast : ModProjectile
    {
        int bounceCount = 0;
        public override void SetDefaults()
        {
            projectile.name = "Wind Field";
            projectile.width = 180;
            projectile.height = 50;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.scale = 1f;
            projectile.penetrate = 25;
            projectile.Opacity = 0f;
            projectile.timeLeft = 180;
            aiType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.75f, 1f, 0.5f);
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width * -projectile.direction, projectile.height + 2, mod.DustType("GreenLight"), ((Main.rand.NextFloat() - 0.95f * 10)* -projectile.direction) * (Main.rand.NextFloat() + 1f) / 2, (Main.rand.NextFloat()*-1f) * 0.5f);
            }
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width * -projectile.direction, projectile.height + 2, 16, ((Main.rand.NextFloat() - 1f * 20) * -projectile.direction) * (Main.rand.NextFloat() + 1f) / 2, (Main.rand.NextFloat()*-1f) * 0.5f);
            }
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height + 2, mod.DustType("GreenLight"), (Main.rand.NextFloat() - 0.5f) * Main.rand.NextFloat(), (Main.rand.NextFloat()) * Main.rand.NextFloat() *- 1);
            }
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height + 2, mod.DustType("YellowLight"), (Main.rand.NextFloat() - 0.5f) * Main.rand.NextFloat(), (Main.rand.NextFloat()) * Main.rand.NextFloat() * -1);
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 9; i++) { }
            {
                if (Main.rand.Next(3) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("ShortSparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                else if (Main.rand.Next(3) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AncientLight, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];

            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.DryadsWardDebuff, 240);
            }
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Slow, 240);
            }
        }
    }
}