using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Melee
{
	public class Tualang : ModProjectile
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
            projectile.knockBack = 0.3f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tualang");
        }

        public override bool PreAI()
        {
	        projectile.spriteDirection = projectile.direction;
	        return base.PreAI();
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

            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.GrassBlades, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f);
            }

            if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
            {
                projectile.ai[0] -= 1.1f; //How far the spear goes back
            }
            else
            {
                projectile.ai[0] += 0.6f; //How far the spear goes
            }

            //Kill projectile if item is done being animated
            if (Main.player[projectile.owner].itemAnimation == 0)
			{
				projectile.Kill();
			}
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 300);
        }

    }
}