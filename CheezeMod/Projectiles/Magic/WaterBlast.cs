using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Magic
{
    public class WaterBlast : ModProjectile
    {
        int bounceCount = 10;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WaterBolt);
            projectile.width = 15;
            projectile.height = 15;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.scale = 1f;
            projectile.timeLeft = 550;
            projectile.penetrate = 6;
            aiType = ProjectileID.WaterBolt;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Blast");
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.25f, 0.4f, 1f);
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("BlueLight"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 29, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];

            if (Main.rand.Next(12) == 0)
            {
                target.AddBuff(BuffID.Frostburn, 180);
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            if (bounceCount <= 0 && Main.rand.Next(3) >= 1)
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
                if (bounceCount % 2 == 0)
                {
                    projectile.ai[0] += 0.5f;
                }
                if (bounceCount % 2 != 0)
                {
                    projectile.ai[1] += 0.5f;
                }
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
                bounceCount--;
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int i = 0; i < 9; i++) { }
            {
                if (Main.rand.Next(3) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("BlueLight"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                else if (Main.rand.Next(3) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 29, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
            }
        }
    }
}