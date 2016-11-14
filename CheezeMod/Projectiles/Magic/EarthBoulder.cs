using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Magic
{
    public class EarthBoulder : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
            projectile.name = "Earth Boulder";
            projectile.width = 24;
            projectile.height = 24;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.scale = 0.9f;
            projectile.timeLeft = 490;
            projectile.penetrate = 6;
            aiType = ProjectileID.BoulderStaffOfEarth;
        }
        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.25f, 0.4f, 1f);
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("PurpleLight"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];

            if (Main.rand.Next(12) == 0)
            {
                target.AddBuff(BuffID.ShadowFlame, 180);
            }
        }
    }
}