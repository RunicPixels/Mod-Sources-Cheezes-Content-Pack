using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class UltraHeavyLancer : ModProjectile
    {
        public bool canExplode = true;
        int bonusTime = 5;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bullet);
            projectile.name = "Ultra Heavy Lancer shot";
            projectile.width = 11;
            projectile.height = 11;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 300;
            projectile.scale = 2f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            if(projectile.timeLeft == 300)
            {
                projectile.scale = 2f;
            }
            if (projectile.timeLeft == 299)
            {
                projectile.scale = 1.5f;
            }
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.5f, 1.1f, 0.3f);
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            // projectile.velocity.X = CheezeMod.CalculateSpread(30f, projectile.velocity.X, projectile.velocity.Y, 'X');
            // projectile.velocity.Y = CheezeMod.CalculateSpread(30f, projectile.velocity.X, projectile.velocity.Y, 'Y');
            if (Main.rand.Next(4) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 1.2f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.5f;
            }
            if (Main.rand.Next(3) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 1.6f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.5f;
            }
            if (Main.rand.Next(2) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 1.6f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.3f;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];
            target.AddBuff(BuffID.CursedInferno, 60);
            target.AddBuff(BuffID.Midas, 60);
            target.AddBuff(BuffID.Ichor, 60);
            if (Main.rand.Next(8) == 0 && canExplode)
            {
                explode();
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            if (Main.rand.Next(8) == 0 && canExplode)
            {
                explode();
            }
            if(!canExplode)
            {
                return false;
            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 7; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 2f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.1f;
            }
            for (int k = 0; k < 7; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 2f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.1f;
            }
            for (int k = 0; k < 8; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 2f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.1f;
            }
            for (int k = 0; k < 1 + Main.rand.Next(2); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2(Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke1);
                Main.gore[num1].timeLeft = Main.rand.Next(15) + 10;
            }
            for (int k = 0; k < 1 + Main.rand.Next(2); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2(Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke2);
                Main.gore[num1].timeLeft = Main.rand.Next(15) + 10;
            }
            for (int k = 0; k < 1 + Main.rand.Next(2); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2(Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke3);
                Main.gore[num1].timeLeft = Main.rand.Next(15) + 10;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }
        public void explode()
        {
            Main.PlaySound(2, projectile.position, 62);
            projectile.penetrate = 5;
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 96;
            projectile.height = 96;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            projectile.knockBack = 8f;
            projectile.damage = projectile.damage + 20;
            for (int k = 0; k < 12; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, Main.rand.Next(10) - 5, Main.rand.Next(10) - 5, 255, default(Color), 4f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
            }
            for (int k = 0; k < 12; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("GreenLight"), Main.rand.Next(10) - 5, Main.rand.Next(10) - 5);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
            }
            for (int k = 0; k < 1 + Main.rand.Next(2); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2(Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke1);
                Main.gore[num1].timeLeft = Main.rand.Next(30) + 40;
            }
            for (int k = 0; k < 1 + Main.rand.Next(2); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2(Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke2);
                Main.gore[num1].timeLeft = Main.rand.Next(30) + 30;
            }
            for (int k = 0; k < 1 + Main.rand.Next(2); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2(Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke3);
                Main.gore[num1].timeLeft = Main.rand.Next(30) + 20;
            }
            canExplode = false;
            projectile.hide = true;
            projectile.timeLeft = bonusTime;
            projectile.extraUpdates = bonusTime;
        }
    }
}