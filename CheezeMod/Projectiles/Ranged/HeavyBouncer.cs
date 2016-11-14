using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class HeavyBouncer : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
            projectile.name = "Heavy Bouncer";
            projectile.width = 28;
            projectile.height = 28;
            projectile.scale = 1f;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.timeLeft = 240;
            projectile.penetrate = 1;
            projectile.knockBack *= 2;
            aiType = ProjectileID.BoulderStaffOfEarth;
        }
        public override void AI()
        {
            if (Main.rand.Next(4) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("ShortSparkle"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
                Main.dust[num1].noGravity = true;
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int i = 0; i <= Main.rand.Next(3) + 3; i++)
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, (projectile.oldVelocity.X * 1f) / 4 - 2 + Main.rand.Next(4), (projectile.oldVelocity.Y * 1f) / 2 - 1 - Main.rand.Next(4), mod.ProjectileType("HeavyBouncerFragment"), (int)(projectile.damage * 0.75f), projectile.knockBack / 2, projectile.owner);
            }
            for (int i = 0; i < Main.rand.Next(4) + 4; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            for (int i = 0; i < Main.rand.Next(5) + 3; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.timeLeft > 15)
            {
                projectile.timeLeft = 15;
            }
            return base.OnTileCollide(oldVelocity);
        }
    }
}