using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Summoning
{
	public class AgentOfDoom : HoverShooter
	{
        bool platformThrough = false;
		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.BabySlime);
            projectile.alpha = 0;
			projectile.netImportant = true;
			projectile.friendly = true;
            projectile.height = 29;
            projectile.width = 20;
            projectile.scale = 0.95f;
            Main.projFrames[projectile.type] = 6;
			Main.projPet[projectile.type] = true;
            drawOriginOffsetY = -2;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 360000;
            aiType = ProjectileID.BabySlime;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Agent of Doom");
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            Player player = Main.player[projectile.owner];
            if (platformThrough)
            {
                fallThrough = true;
                return false;
            }
            else
            {
                fallThrough = false;
                return true;
            }
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            CheezePlayer modPlayer = player.GetModPlayer<CheezePlayer>();
            if (player.dead)
            {
                modPlayer.agentDreadMinion = false;
                projectile.active = false;
            }
            if (modPlayer.agentDreadMinion)
            {
                projectile.timeLeft = 2;
            }
        }

        public override bool PreAI()
        {
			Player player = Main.player[projectile.owner];
			CheezePlayer modPlayer = player.GetModPlayer<CheezePlayer>();
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
            Vector2 targetPos = projectile.position;
            float targetDist = 500;
            bool target = false;
            if (projectile.frame > 1)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y + 2), projectile.width, projectile.height / 2, 6);
                    Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.9f, 0.6f, 0.3f);
                }
            }
            for (int k = 0; k < 200; k++)
            {
                NPC npc = Main.npc[k];
                if (npc.CanBeChasedBy(this, false))
                {
                    float distance = Vector2.Distance(npc.Center, projectile.Center);
                    if ((distance < targetDist || !target) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                    {
                        targetDist = distance;
                        targetPos = npc.Center;
                        target = true;
                        projectile.tileCollide = !Agent.CompareY(npc.Center.Y - 50, projectile.Center.Y);
                    }
                }
            }

        }
	}
}