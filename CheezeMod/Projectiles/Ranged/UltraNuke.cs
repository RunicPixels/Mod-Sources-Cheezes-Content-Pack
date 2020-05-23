using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class UltraNuke : ModProjectile
    {
        public bool canExplode = true;
        int bonusTime = 60;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
            projectile.width = 24;
            projectile.height = 24;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.scale = 1f;
            projectile.timeLeft = 160;
            projectile.penetrate = 40;
            aiType = ProjectileID.BoulderStaffOfEarth;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultra Nuke");
        }

        public override bool PreAI()
        {
            projectile.spriteDirection = projectile.direction;
            return base.PreAI();
        }
        
        public override void AI()
        {
            if (Main.rand.Next(20) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("BlueLight"), Main.rand.Next(10) - 5, Main.rand.Next(10) - 5);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
            }
            if (Main.rand.Next(20) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("PurpleLight"), Main.rand.Next(10) - 5, Main.rand.Next(10) - 5);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
            }
            if (projectile.timeLeft == 1 && canExplode)
            {
                Explode();
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];
            target.AddBuff(mod.BuffType("ExtremeRadiation"), 420);
            if (canExplode)
            {
                Explode();
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (canExplode)
            {
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Explode();
            }
            return false;
        }

        public void Explode()
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62, 1.2f);
            projectile.velocity.X = 0;
            projectile.velocity.Y = 0;
            int gore1 = Gore.NewGore(new Vector2(projectile.position.X-25, projectile.position.Y-225) - projectile.Size, new Vector2(0, 0), mod.GetGoreSlot("Gores/Explosions/UltraNuke"));
            Main.gore[gore1].rotation = 0f;
            Gore.NewGore(projectile.position - projectile.Size, new Vector2(0, 0), mod.GetGoreSlot("Gores/Explosions/DreadBomb4"));
            Lighting.AddLight(projectile.position, 1.5f, 3f, 1f);
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 320;
            projectile.height = 320;
            projectile.penetrate = 40;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            projectile.knockBack = 12f;
            for (int k = 0; k < 5+ Main.rand.Next(2); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2 (Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke1);
                Main.gore[num1].timeLeft = Main.rand.Next(50) + 65;
            }
            for (int k = 0; k < 5+ Main.rand.Next(2); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2(Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke2);
                Main.gore[num1].timeLeft = Main.rand.Next(30) + 60;
            }
            for (int k = 0; k < 5+ Main.rand.Next(5); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2(Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke3);
                Main.gore[num1].timeLeft = Main.rand.Next(20) + 55;
            }
            for (int k = 0; k < 15; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("GreenLight"), Main.rand.Next(10) - 5, Main.rand.Next(10) - 5);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
            }
            for (int k = 0; k < 15; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("ExtremeRadiation"), Main.rand.Next(10) - 5, Main.rand.Next(10) - 5);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
            }
            for (int k = 0; k < 12; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, Main.rand.Next(10) - 5, Main.rand.Next(10) - 5);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
            }
            projectile.hide = true;
            projectile.timeLeft = bonusTime;
            projectile.extraUpdates = bonusTime;
            canExplode = false;
        }
    }
}