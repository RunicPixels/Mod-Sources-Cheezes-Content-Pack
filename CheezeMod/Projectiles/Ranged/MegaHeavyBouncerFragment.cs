using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class MegaHeavyBouncerFragment : ModProjectile
    {
        int bonusTime = 2;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
            projectile.name = "Mega Heavy Bouncer";
            projectile.width = 18;
            projectile.height = 18;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.scale = 1f;
            projectile.timeLeft = 150;
            projectile.penetrate = 2;
            aiType = ProjectileID.BoulderStaffOfEarth;
            
        }
        public override void AI()
        {
            if (Main.rand.Next(20) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("LiquidNitrogen"), projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
                Main.dust[num1].noGravity = true;
            }
            if (bonusTime > 0)
            {
                projectile.timeLeft += Main.rand.Next(20);
                bonusTime--;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(Main.rand.Next(2) == 0)
            {
            target.AddBuff(BuffID.Frostburn, 100);
            }
            Player player = Main.player[(int)projectile.ai[1]];
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int i = 0; i < 3; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("LiquidNitrogen"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            for (int i = 0; i < Main.rand.Next(5) + 3; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 56, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
        }
    }
}