using System;
using CheezeMod.Items.Vanilla;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Thrown
{
    public class BombGloveStickyGrenade : ModProjectile
    {
        private bool canUpdate = true;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.StickyGrenade);
            aiType = ProjectileID.StickyGrenade;
            projectile.width = 14;
            projectile.height = 14;
            projectile.timeLeft = 400;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bomb Glove Sticky Grenade");
        }
        
        public override bool PreAI()
        {
            projectile.spriteDirection = projectile.direction;
            return base.PreAI();
        }
        
        public override bool PreKill(int timeLeft) {
            projectile.type = ProjectileID.StickyGrenade;
            return true;
        }

        public override void PostAI()
        {
            projectile.type = mod.ProjectileType("BombGloveStickyGrenade");
            base.PostAI();
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.type = ProjectileID.StickyGrenade;
            if (canUpdate)
            {
                if(projectile.timeLeft > 200)projectile.timeLeft = 200;
                canUpdate = false;
            }
            //projectile.velocity = Vector2.Zero;
            return base.OnTileCollide(projectile.velocity);
        }
    }
}