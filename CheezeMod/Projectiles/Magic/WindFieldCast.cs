using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Magic
{
    public class WindFieldCast : ModProjectile
    {
        int bounceCount = 0;
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 28;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.scale = 0.75f;
            projectile.penetrate = 1;
            projectile.Opacity = 0.5f;
            projectile.timeLeft = 30;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wind Cast");
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.75f, 1f, 0.5f);
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("YellowLight"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("GreenLight"), projectile.oldVelocity.X * 0.4f, projectile.oldVelocity.Y * 0.4f);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundLoader.customSoundType,projectile.position,SoundLoader.GetSoundSlot(SoundType.Custom, "Sounds/Custom/Wind2"));
            for (int i = 0; i < 9; i++) { }
            {
                if (Main.rand.Next(3) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("ShortSparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
                else if (Main.rand.Next(3) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AncientLight, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                }
            }
            Projectile.NewProjectile(projectile.position.X+projectile.velocity.X, projectile.position.Y+projectile.velocity.Y, projectile.velocity.X*0.001f, 0, mod.ProjectileType("WindFieldBlast"), projectile.damage/2, projectile.knockBack / 3, projectile.owner);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];

            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.DryadsWardDebuff, 180);
            }
        }
    }
}