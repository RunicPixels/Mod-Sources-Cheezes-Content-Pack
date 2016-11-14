using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Magic
{
    public class InfernoFireBlast : ModProjectile
    {
        int bounceCount = 7;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BallofFire);
            projectile.name = "Inferno Fire Blast";
            projectile.width = 20;
            projectile.height = 24;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.scale = 0.8f;
            projectile.penetrate = 1;
            projectile.timeLeft = 420;
            aiType = ProjectileID.BallofFire;
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 1f, 0.7f, 0.2f);
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("YellowLight"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("OrangeLight"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 127, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            if (Main.rand.Next(5) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, ProjectileID.InfernoFriendlyBlast, projectile.damage / 4, projectile.knockBack / 2, projectile.owner);
            for (int i = 0; i < 9; i++) { }
            {
                if (Main.rand.Next(3) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("YellowLight"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
                }
                if (Main.rand.Next(2) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("OrangeLight"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
                }
                if (Main.rand.Next(4) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 127, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
                }
                if (Main.rand.Next(5) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
                }
                if (Main.rand.Next(1) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
                }
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
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
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
                bounceCount--;
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.OnFire, 300);
            }
        }
    }
}