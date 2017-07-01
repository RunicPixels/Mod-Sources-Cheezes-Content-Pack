using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Magic
{
    public class BlueLaserStaff : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 15;
            projectile.height = 10;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 300;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Laser");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0f, 0.4f, 1f);
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }
    }
}