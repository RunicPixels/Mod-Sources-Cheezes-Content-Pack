using System;
using CheezeMod.Items.Vanilla;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Thrown
{
    public class BombGloveBeenade : ModProjectile
    {
        private bool canUpdate = true;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BouncyGrenade);
            aiType = ProjectileID.BouncyGrenade;
            projectile.width = 14;
            projectile.height = 14;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bomb Glove Beenade");
        }
        
        public override bool PreAI()
        {
            projectile.spriteDirection = projectile.direction;
            return base.PreAI();
        }
        
        public override bool PreKill(int timeLeft) {
            projectile.type = ProjectileID.Beenade;
            return true;
        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!canUpdate) return base.OnTileCollide(projectile.velocity);
            projectile.timeLeft = 200;
            canUpdate = false;
            
            
            return base.OnTileCollide(projectile.velocity);
        }
        
    }
}