using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Thrown
{
    public class BoneKunai : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ThrowingKnife);
            projectile.width = 18;
            projectile.height = 20;
            projectile.thrown = true;
            projectile.friendly = true;
            projectile.timeLeft = 700;
            projectile.scale = 0.8f;
            projectile.penetrate += 2;
            aiType = ProjectileID.ThrowingKnife;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Kunai");
        }
        
        public override bool PreAI()
        {
            projectile.spriteDirection = projectile.direction;
            return base.PreAI();
        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            projectile.Kill();
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(6) == 0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - projectile.velocity.Y - 300f, Main.rand.NextFloat() * 4f - 2f, Main.rand.NextFloat() * 3 + 6f, ProjectileID.Bone, projectile.damage, projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
            }
        }

        public override void Kill(int timeLeft)
        {
            if (Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("BoneKunai"));
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 1, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.75f);
            }
        }
    }
}