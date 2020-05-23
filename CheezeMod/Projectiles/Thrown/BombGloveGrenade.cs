using System;
using CheezeMod.Items.Vanilla;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Thrown
{
    public class BombGloveGrenade : ModProjectile
    {
        private bool canUpdate = true;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Grenade);
            aiType = ProjectileID.Grenade;
            projectile.width = 14;
            projectile.height = 14;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bomb Glove Grenade");
        }
        
        public override bool PreAI()
        {
            projectile.spriteDirection = projectile.direction;
            return base.PreAI();
        }
        
        public override bool PreKill(int timeLeft) {
            projectile.type = ProjectileID.Grenade;
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!canUpdate) return true;
            projectile.timeLeft = 150;
            canUpdate = false;

            return base.OnTileCollide(projectile.velocity);
        }
    }
}