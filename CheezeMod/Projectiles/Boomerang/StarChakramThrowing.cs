using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Boomerang
{
    public class StarChakramThrowing : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ThornChakram);
            projectile.width = 20;
            projectile.height = 20;
            projectile.scale = 1.3f;
            projectile.thrown = true;
            projectile.friendly = true;
            projectile.penetrate = 12;
            projectile.timeLeft = 600;
            aiType = ProjectileID.Bananarang;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Chakram");
        }

        public override void AI()
        {

            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.8f, 0.8f, 0.4f);
            if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("ShortSparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
            Projectile.NewProjectile(projectile.Center.X - projectile.velocity.X * 20f, projectile.Center.Y - projectile.velocity.Y * 20f, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, mod.ProjectileType("StarStorm2"), projectile.damage, projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 25);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }

    }
}