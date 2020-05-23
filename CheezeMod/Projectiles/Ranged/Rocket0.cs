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
            projectile.damage = 11;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.penetrate = 10;
            projectile.aiStyle = ProjectileID.RocketI;
            aiType = ProjectileID.RocketI;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rocket 0");
        }

        public override bool PreAI()
        {
            projectile.spriteDirection = projectile.direction;
            return base.PreAI();
        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }
    }
}