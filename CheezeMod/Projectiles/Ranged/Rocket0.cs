using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class Rocket0 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.RocketI);
            projectile.name = "Rocket 0";
            projectile.damage = 11;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.penetrate = 10;
            projectile.aiStyle = ProjectileID.RocketI;
            aiType = ProjectileID.RocketI;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }
    }
}