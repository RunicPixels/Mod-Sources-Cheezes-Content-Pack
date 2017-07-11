using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Boomerang
{
    public class BonemerangThrowing : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bananarang);
            projectile.width = 22;
            projectile.height = 42;
            projectile.thrown = true;
            projectile.friendly = true;
            projectile.penetrate = 20;
            projectile.timeLeft = 700;
            aiType = ProjectileID.Bananarang;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bonemerang");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }

    }
}