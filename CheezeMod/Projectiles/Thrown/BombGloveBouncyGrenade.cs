using System;
using CheezeMod.Items.Vanilla;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Thrown
{
    public class BombGloveBouncyGrenade : ModProjectile
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
            DisplayName.SetDefault("Bomb Glove Bouncy Grenade");
        }
        
        public override bool PreAI()
        {
            projectile.spriteDirection = projectile.direction;
            return base.PreAI();
        }
        
        public override bool PreKill(int timeLeft) {
            projectile.type = ProjectileID.BouncyGrenade;
            return true;
        }

        public override void PostAI()
        {
            projectile.type = mod.ProjectileType("BombGloveBouncyGrenade");
            base.PostAI();
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.type = ProjectileID.BouncyGrenade;
            if (!canUpdate) return base.OnTileCollide(projectile.velocity);
            projectile.timeLeft = 300;
            canUpdate = false;
            
            
            return base.OnTileCollide(projectile.velocity);
        }
    }
}