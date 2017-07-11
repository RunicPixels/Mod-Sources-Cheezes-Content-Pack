using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Boomerang
{
    public class Kaboomerang : ModProjectile
    {
        public bool canExplode = true;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bananarang);
            projectile.width = 36;
            projectile.height = 36;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.scale = 0.75f;
            projectile.penetrate = 8;
            projectile.timeLeft = 700;
            aiType = ProjectileID.Bananarang;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kaboomerang");
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            base.OnHitNPC(target, damage, knockback, crit);
            if(canExplode)
            {
                for (int index1 = 0; index1 < 30; ++index1)
                {
                    int index2 = Dust.NewDust(new Vector2((float)projectile.position.X, (float)projectile.position.Y), projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, new Color(200, 150, 50), 1.5f);
                    Dust dust = Main.dust[index2];
                }
                for (int index1 = 0; index1 < 20; ++index1)
                {
                    int index2 = Dust.NewDust(new Vector2((float)projectile.position.X, (float)projectile.position.Y), projectile.width, projectile.height, 6, 0.0f, 0.0f, 100, new Color(200, 150, 50), 3.5f);
                    Main.dust[index2].noGravity = true;
                    Dust dust1 = Main.dust[index2];
                    int index3 = Dust.NewDust(new Vector2((float)projectile.position.X, (float)projectile.position.Y), projectile.width, projectile.height, 6, 0.0f, 0.0f, 100, new Color(200, 150, 50), 1.5f);
                    Dust dust2 = Main.dust[index3];
                }

                for (int index1 = 0; index1 < 3; ++index1)
                {
                    float num = 0.33f;
                    if (index1 == 1)
                        num = 0.66f;
                    if (index1 == 2)
                        num = 1f;
                    int index2 = Gore.NewGore(new Vector2((float)(projectile.position.X + (double)(projectile.width / 2) - 24.0), (float)(projectile.position.Y + (double)(projectile.height / 2) - 24.0)), new Vector2(Main.rand.NextFloat(-2, 1), Main.rand.NextFloat(-2, 2)), Main.rand.Next(61, 64), 1f);
                    Gore gore1 = Main.gore[index2];
                    int index3 = Gore.NewGore(new Vector2((float)(projectile.position.X + (double)(projectile.width / 2) - 24.0), (float)(projectile.position.Y + (double)(projectile.height / 2) - 24.0)), new Vector2(Main.rand.NextFloat(-1, 0), Main.rand.NextFloat(-1, 1)), Main.rand.Next(61, 64), 1f);
                    Gore gore2 = Main.gore[index3];
                    int index4 = Gore.NewGore(new Vector2((float)(projectile.position.X + (double)(projectile.width / 2) - 24.0), (float)(projectile.position.Y + (double)(projectile.height / 2) - 24.0)), new Vector2(Main.rand.NextFloat(-1.5f, 0.5f), Main.rand.NextFloat(-1.5f, 1.5f)), Main.rand.Next(61, 64), 1f);
                    Gore gore3 = Main.gore[index4];
                }
                Main.PlaySound(SoundID.Item62, projectile.position);
                canExplode = false;
                projectile.width = 66;
                projectile.height = 66;
            }
            else
            {
                projectile.width = 36;
                projectile.height = 36;
            }
            
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }

    }
}