using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Summoning
{
	public class AgentOfDoom : ModProjectile
	{
		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.BabySlime);
            projectile.alpha = 0;
			projectile.netImportant = true;
			projectile.name = "Agent of Doom";
			projectile.friendly = true;
            projectile.height = 29;
            projectile.width = 20;
            projectile.scale = 0.875f;
            Main.projFrames[projectile.type] = 6;
			Main.projPet[projectile.type] = true;
            drawOriginOffsetY = -10;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 360000;
            aiType = ProjectileID.BabySlime;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
		}

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            fallThrough = false;
        }

        public override bool PreAI()
        {
			Player player = Main.player[projectile.owner];
			CheezePlayer modPlayer = player.GetModPlayer<CheezePlayer>(mod);
			if (player.dead)
			{
				modPlayer.agentMinion = false;
                return false;
			}
			if (modPlayer.agentMinion)
			{
				projectile.timeLeft = 2;
			}
            return true;
		}

		public override void AI()
		{
			if(projectile.frame > 1)
            {
                if(Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y + 2), projectile.width, projectile.height / 2, 6);
                    Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.9f, 0.6f, 0.3f);
                }
            }

		}
	}
}