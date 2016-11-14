using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Magic
{
    public class HugeEarthBoulder : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
            projectile.name = "Huge Earth Boulder";
            projectile.width = 32;
            projectile.height = 32;
            projectile.scale = 0.9f;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.timeLeft = 240;
            projectile.penetrate = 5;
            projectile.knockBack *= 2;
            aiType = ProjectileID.BoulderStaffOfEarth;
        }
        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.25f, 0.4f, 1f);
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("PurpleLight"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int i = 0; i < Main.rand.Next(3)+1; i++)
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, (projectile.oldVelocity.X * 1f) - 7 + Main.rand.Next(14), (projectile.oldVelocity.Y * 1f) + -7 + Main.rand.Next(14), mod.ProjectileType("EarthBoulder"), projectile.damage / 2, projectile.knockBack / 2, projectile.owner);
            } 
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];

            if (Main.rand.Next(6) == 0)
            {
                target.AddBuff(BuffID.ShadowFlame, 180);
            }
        }
    }
}