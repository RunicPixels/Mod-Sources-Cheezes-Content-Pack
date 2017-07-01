using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Thrown
{
    public class OrichalcumKunai : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ThrowingKnife);
            projectile.width = 18;
            projectile.height = 20;
            projectile.thrown = true;
            projectile.friendly = true;
            projectile.timeLeft = 700;
            projectile.scale = 0.9f;
            projectile.penetrate = 3;
            aiType = ProjectileID.ThrowingKnife;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orichalcum Kunai");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
            if (Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("OrichalcumKunai"));
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 1, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.75f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            {
                if (Main.rand.Next(5) == 0)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        Projectile.NewProjectile(projectile.Center.X - 720f, projectile.Center.Y, 16f, projectile.velocity.Y * 0f, ProjectileID.FlowerPetal, projectile.damage/2, projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
                    }
                    else
                    {
                        Projectile.NewProjectile(projectile.Center.X + 720f, projectile.Center.Y, -16f, projectile.velocity.Y * 0f, ProjectileID.FlowerPetal, projectile.damage/2, projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
                    }
                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 8);
                }
            }
        }

    }
}