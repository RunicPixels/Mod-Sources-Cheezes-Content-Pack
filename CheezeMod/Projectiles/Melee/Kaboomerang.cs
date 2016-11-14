using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Melee
{
    public class Kaboomerang : ModProjectile
    {
        
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bananarang);
            projectile.name = "Kaboomemerang";
            projectile.width = 36;
            projectile.height = 36;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.scale = 0.75f;
            projectile.penetrate = 8;
            projectile.timeLeft = 700;
            aiType = ProjectileID.Bananarang;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
            if (projectile.scale > 0f) {
                Projectile.NewProjectile(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2), projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("Kaboom"), projectile.damage, projectile.knockBack);
            }
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            projectile.width = 128;
            projectile.height = 128;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            projectile.velocity.X = projectile.velocity.X * 0.1f;
            projectile.velocity.Y = projectile.velocity.Y * 0.1f;
            projectile.scale = 0f;
            projectile.timeLeft = 30;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }

    }
}