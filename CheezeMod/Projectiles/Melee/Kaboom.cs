using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Melee
{
    public class Kaboom : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Landmine);
            projectile.name = "Kaboom";
            projectile.width = 128;
            projectile.height = 128;
            projectile.penetrate = 8;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.timeLeft = 1;
            aiType = ProjectileID.Landmine;
        }

        public override bool PreKill(int timeLeft)
        {
            projectile.type = ProjectileID.Landmine;
            projectile.friendly = true;
            projectile.hostile = false;
            return true;
        }
    }
}