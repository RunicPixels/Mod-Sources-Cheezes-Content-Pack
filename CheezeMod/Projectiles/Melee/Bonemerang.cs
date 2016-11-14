using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Melee
{
    public class Bonemerang : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bananarang);
            projectile.name = "Bonemerang";
            projectile.width = 22;
            projectile.height = 42;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.penetrate = 20;
            projectile.timeLeft = 700;
            aiType = ProjectileID.Bananarang;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }

    }
}