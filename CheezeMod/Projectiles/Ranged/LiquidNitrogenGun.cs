using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
	public class LiquidNitrogenGun : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
            projectile.penetrate = 1;
			projectile.timeLeft = 150;
			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 5;
			aiType = ProjectileID.MolotovFire;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Liquid Nitrogen Gun");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0f, 0.4f, 0.9f);
            if (Main.rand.Next(10) == 0)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("LiquidNitrogen"), projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];
            target.AddBuff(BuffID.Frostburn, 300);
            target.AddBuff(BuffID.Chilled, 120);
            target.AddBuff(BuffID.Frozen, 10);
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 3; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("LiquidNitrogen"), projectile.oldVelocity.X * 0.3f, projectile.oldVelocity.Y * -0.3f);
            }
        }

    }
}