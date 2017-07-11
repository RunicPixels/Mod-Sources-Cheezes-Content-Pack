using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CheezeMod.Projectiles.Magic
{
    public class ThornBlast : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.scale = 1f;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 30;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorn Blast");
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.1f, 0.12f, 0f);
            projectile.rotation += (float)projectile.direction * 0.25f;
            projectile.velocity.Y += projectile.ai[0];
            if (Main.rand.Next(5) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.GrassBlades, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 18, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 4; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.GrassBlades, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            float spread = 45f * 0.0174f; // 45 degrees converted to radians
            float baseSpeed = 10f;
            double baseAngle = Math.Atan2(5, 5);
            double[] Angle = { baseAngle + 0 + Main.rand.NextFloat() * spread, baseAngle + 1 + Main.rand.NextFloat() * spread, baseAngle + +2 * spread + Main.rand.NextFloat(), baseAngle + +3 + Main.rand.NextFloat() * spread, baseAngle + +4 + Main.rand.NextFloat() * spread, baseAngle + +5 + Main.rand.NextFloat() * spread, baseAngle + +6 + Main.rand.NextFloat() * spread, baseAngle + +7 + Main.rand.NextFloat() * spread };
            float[] speedXArray = { baseSpeed * (float)Math.Sin(Angle[0]), baseSpeed * (float)Math.Sin(Angle[1]), baseSpeed * (float)Math.Sin(Angle[2]), baseSpeed * (float)Math.Sin(Angle[3]), baseSpeed * (float)Math.Sin(Angle[4]), baseSpeed * (float)Math.Sin(Angle[5]), baseSpeed * (float)Math.Sin(Angle[6]), baseSpeed * (float)Math.Sin(Angle[7]) };
            float[] speedYArray = { baseSpeed * (float)Math.Cos(Angle[0]), baseSpeed * (float)Math.Cos(Angle[1]), baseSpeed * (float)Math.Cos(Angle[2]), baseSpeed * (float)Math.Cos(Angle[3]), baseSpeed * (float)Math.Cos(Angle[4]), baseSpeed * (float)Math.Cos(Angle[5]), baseSpeed * (float)Math.Cos(Angle[6]), baseSpeed * (float)Math.Cos(Angle[7]) };
            for (int i = 0; i < speedXArray.Length; i++)
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, speedXArray[i], speedYArray[i], ProjectileID.HornetStinger, projectile.damage/3, projectile.knockBack/2, projectile.owner);
            }
            for (int k = 0; k < 3; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 18, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
        }
    }
}