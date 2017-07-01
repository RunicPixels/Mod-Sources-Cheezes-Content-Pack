using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Magic
{
    public class PsychicBomb : ModProjectile
    {
        private bool exploded = false;
        private bool explodedParticles = false;
        public int bounceCount = 0;
        public float maxSize = 3f;
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.Opacity = 0.4f;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.scale = 1f;
            projectile.penetrate = 6;
            projectile.timeLeft = 180;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Psychic Bomb");
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.75f, 1f, 0.5f);
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 112, projectile.oldVelocity.X * 0.2f + (Main.rand.NextFloat() - 1 * 0.2f), projectile.oldVelocity.Y * 0.2f + (Main.rand.NextFloat() - 1 * 0.2f));
                Main.dust[dust].scale = 0.5f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 114, projectile.oldVelocity.X * 0.3f + (Main.rand.NextFloat() - 1 * 0.3f), projectile.oldVelocity.Y * 0.3f + (Main.rand.NextFloat() - 1 * 0.3f));
                Main.dust[dust].scale = 0.5f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 111, projectile.oldVelocity.X * 0.4f + (Main.rand.NextFloat() - 1 * 0.4f), projectile.oldVelocity.Y * 0.4f + (Main.rand.NextFloat() - 1 * 0.4f));
                Main.dust[dust].scale = 0.5f;
            }
            if (projectile.scale >= maxSize)
            {
                
                if (projectile.timeLeft == 5) {
                    for (int i = 0; i < (int)projectile.scale * 8; i++)
                    {
                        if (Main.rand.Next(4) == 0)
                        {
                            Dust.NewDust(projectile.position, projectile.width, projectile.height, 112, projectile.velocity.X * 0.4f + Main.rand.NextFloat() - 1, projectile.velocity.Y * 0.4f + Main.rand.NextFloat() - 1);
                        }
                        if (Main.rand.Next(3) == 0)
                        {
                            Dust.NewDust(projectile.position, projectile.width, projectile.height, 112, projectile.velocity.X * 0.4f + Main.rand.NextFloat() - 1, projectile.velocity.Y * 0.4f + Main.rand.NextFloat() - 1);
                        }
                        if (Main.rand.Next(2) == 0)
                        {
                            Dust.NewDust(projectile.position, projectile.width, projectile.height, 111, projectile.velocity.X * 0.4f + Main.rand.NextFloat() - 1, projectile.velocity.Y * 0.4f + Main.rand.NextFloat() - 1);
                        }
                    }
                    projectile.hide = true;
                    projectile.width = (int)(projectile.width * maxSize);
                    projectile.height = (int)(projectile.height * maxSize);
                    projectile.knockBack *= 3f;
                }
                if (projectile.timeLeft > 10) {
                    projectile.timeLeft = 10;

                }
            }
            if(explodedParticles)
            {
                for (int i = 0; i < (int)projectile.scale * 3; i++)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, 112, projectile.velocity.X * 0.4f + Main.rand.NextFloat() - 1, projectile.velocity.Y * 0.4f + Main.rand.NextFloat() - 1);
                    }
                    if (Main.rand.Next(3) == 0)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, 112, projectile.velocity.X * 0.4f + Main.rand.NextFloat() - 1, projectile.velocity.Y * 0.4f + Main.rand.NextFloat() - 1);
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, 111, projectile.velocity.X * 0.4f + Main.rand.NextFloat() - 1, projectile.velocity.Y * 0.4f + Main.rand.NextFloat() - 1);
                    }
                }
                explodedParticles = false;
            }
            if (exploded) {
                projectile.scale += maxSize / 20f;
                projectile.velocity *= 0.75f;
                projectile.Opacity += 0.01f;
            }

        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            /*for (int i = 0; i < (int)projectile.scale * 9; i++) {
                if (Main.rand.Next(4) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 112, projectile.velocity.X * 0.4f + Main.rand.NextFloat() -1, projectile.velocity.Y * 0.4f + Main.rand.NextFloat() -1);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 112, projectile.velocity.X * 0.4f + Main.rand.NextFloat() -1, projectile.velocity.Y * 0.4f + Main.rand.NextFloat() -1);
                }
                if (Main.rand.Next(2) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 111, projectile.velocity.X * 0.4f + Main.rand.NextFloat() -1, projectile.velocity.Y * 0.4f + Main.rand.NextFloat() -1);
                }
            }*/
        }

    public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            if (bounceCount <= 0)
            {
                exploded = true;
                explodedParticles = true;
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
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
                bounceCount--;
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            exploded = true;
            explodedParticles = true;
            Player player = Main.player[(int)projectile.ai[1]];

            if (Main.rand.Next(6) == 0)
            {
                target.AddBuff(BuffID.ShadowFlame, 180);
            }
        }
    }
}