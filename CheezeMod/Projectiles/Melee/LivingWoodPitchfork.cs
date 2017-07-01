using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Melee
{
	public class LivingWoodPitchfork : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.scale = 1.1f;
			projectile.aiStyle = 19;
			projectile.timeLeft = 90;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.ownerHitCheck = true;
			projectile.hide = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Wood Pitchfork");
        }

        public override void AI()
        {
			//Spear code
			Main.player[projectile.owner].direction = projectile.direction;
			Main.player[projectile.owner].heldProj = projectile.whoAmI;
			Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
			projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
			projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
			projectile.position += projectile.velocity * projectile.ai[0];if (projectile.ai[0] == 0f)
			{
				projectile.ai[0] = 3f;
				projectile.netUpdate = true;
			}
            if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
            {
                projectile.ai[0] -= 1.1f; //How far the spear goes back
                if (projectile.localAI[0] <= 0f && Main.myPlayer == projectile.owner)
                {
                    if (Main.rand.NextFloat() <= 0.75f) {
                        projectile.localAI[0]++;
                    }
                    Projectile.NewProjectile(projectile.Center.X - projectile.velocity.X * 20f, projectile.Center.Y - projectile.velocity.Y * 20f, projectile.velocity.X * 2f, projectile.velocity.Y * 2f, 206, projectile.damage, projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
                }
            }
            else
            {
                projectile.ai[0] += 0.75f; //How far the spear goes
            }

            //Kill projectile if item is done being animated
            if (Main.player[projectile.owner].itemAnimation == 0)
			{
				projectile.Kill();
			}
		}
	}
}