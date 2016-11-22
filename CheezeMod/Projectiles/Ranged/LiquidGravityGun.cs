using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
	public class LiquidGravityGun : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Liquid Gravity Gun";
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
            projectile.penetrate = 1;
			projectile.timeLeft = 200;
			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 5;
			aiType = ProjectileID.MolotovFire;
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.6f, 0f, 0.6f);
            if (Main.rand.Next(7) == 0)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("LiquidGravity"), projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
                Main.dust[dust].noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];
            target.AddBuff(BuffID.Ichor, 150);
            target.AddBuff(BuffID.ShadowFlame, 150);
            target.AddBuff(mod.BuffType("Downfall"), 150);
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 4; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("LiquidGravity"), projectile.oldVelocity.X * 0.3f, projectile.oldVelocity.Y * -0.3f);
            }
        }

    }
}