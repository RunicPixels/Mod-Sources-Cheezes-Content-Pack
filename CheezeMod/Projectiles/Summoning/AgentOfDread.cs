using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Summoning
{
	public class AgentOfDread : HoverShooter
	{
        int attackCool;
		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.BabySlime);
            projectile.alpha = 0;
			projectile.netImportant = true;
			projectile.name = "Agent of Dread";
			projectile.friendly = true;
            projectile.height = 29;
            projectile.width = 20;
            projectile.scale = 1f;
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
            inertia = 25f;
            shoot = mod.ProjectileType("DreadLaser");
            shootSpeed = 16;
            attackCool = 0;
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
                modPlayer.agentDreadMinion = false;
                return false;
            }
            if (modPlayer.agentDreadMinion)
            {
                projectile.timeLeft = 2;
            }
            return true;
        }

        public override void CheckActive()
        {
			Player player = Main.player[projectile.owner];
			CheezePlayer modPlayer = player.GetModPlayer<CheezePlayer>(mod);
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

		public override void AI()
		{
            Vector2 targetPos = projectile.position;
            float targetDist = viewDist;
            bool target = false;
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
                    }
                }
            }
            if (projectile.frame > 1)
            {
                if(Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y + 2), projectile.width, projectile.height / 2, 6);
                    Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.9f, 0.6f, 0.3f);
                }
            }
            if (target == true && targetDist > 25 && targetDist < 520 && attackCool <= 0)
            {
                Behavior();
                attackCool = 65 + Main.rand.Next(30);
                projectile.tileCollide = false;
            }
            else
            {
                attackCool--;
            }
            if (!Collision.CanHitLine(projectile.position, projectile.width, projectile.height, targetPos, 1, 1) && targetDist > 300)
            {
                projectile.tileCollide = false;
            }
        }
    }
}