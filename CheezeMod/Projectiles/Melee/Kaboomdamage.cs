using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Melee
{
    public class Kaboomdamage : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.damage = 50;
            projectile.melee = true;
            projectile.width = 128;
            projectile.height = 128;
            projectile.penetrate = 8;
            projectile.scale = 1f;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.timeLeft = 60;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kaboom");
        }

    }
}