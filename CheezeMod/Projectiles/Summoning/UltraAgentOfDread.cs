using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Summoning
{
	public class UltraAgentOfDread : HoverShooter
	{
        int attackCool;
        int attackCool2;
		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.Raven);
            projectile.alpha = 0;
			projectile.netImportant = true;
			projectile.friendly = true;
            projectile.height = 29;
            projectile.width = 20;
            projectile.scale = 1.125f;
            Main.projFrames[projectile.type] = 8;
			Main.projPet[projectile.type] = true;
            drawOriginOffsetY = -10;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 360000;
            aiType = ProjectileID.Raven;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            inertia = 25f;
            shoot = mod.ProjectileType("UltraDreadLaser");
            shootSpeed = 16;
            attackCool = 0;
            attackCool2 = 10;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultra Agent of Dread");
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            CheezePlayer modPlayer = player.GetModPlayer<CheezePlayer>();
            if (player.dead)
            {
                modPlayer.agentUltraDreadMinion = false;
                return false;
            }
            if (modPlayer.agentUltraDreadMinion)
            {
                projectile.timeLeft = 2;
            }
            return true;
        }

        public override void CheckActive()
        {

			Player player = Main.player[projectile.owner];
			CheezePlayer modPlayer = player.GetModPlayer<CheezePlayer>();
			if (player.dead)
			{
				modPlayer.agentUltraDreadMinion = false;
			}
			if (modPlayer.agentUltraDreadMinion)
			{
				projectile.timeLeft = 2;
			}
		}

        public override void AI()
		{
            if(Main.rand.Next(5) == 0)
            {
                projectile.velocity *= 1.02f;
                projectile.velocity.Y *= 1.02f;
            }
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.1f, 0.3f, 0.3f);
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
            if(Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y + 2), projectile.width, projectile.height / 2, 135);
                    Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.3f, 0.9f, 0.9f);
                }
            if (target == true && targetDist > 10 && targetDist < 1500 && attackCool <= 0 && Main.rand.Next(3) >= 0)
            {
                shootSpeed = 20;
                shoot = mod.ProjectileType("UltraDreadLaser");
                Behavior();
                attackCool = 43+ Main.rand.Next(15);
                projectile.tileCollide = false;
            }
            else if (target == true && targetDist > 10 && targetDist < 350 && attackCool2 <= 0 && Main.rand.Next(3) == 0)
            {
                shootSpeed = 14;
                shoot = mod.ProjectileType("DreadNuke");
                Behavior();
                attackCool2 = 200 + Main.rand.Next(150);
                projectile.tileCollide = false;
            }
            else
            {
                attackCool--;
                attackCool2--;
            }
            if (!Collision.CanHitLine(projectile.position, projectile.width, projectile.height, targetPos, 1, 1) && targetDist > 100)
            {
                projectile.tileCollide = false;
            }
        }
    }
}