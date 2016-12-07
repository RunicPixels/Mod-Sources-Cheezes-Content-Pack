using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
	public class YellowLasersaber : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.BeamSword);
			item.name = "Yellow Lasersaber";
            item.toolTip = "From the galaxy and far beyond.";
            item.toolTip2 = "This laser is so hot that it burns your enemies, it also shoots lasers.";
            item.width = 48;
            item.height = 50;
            item.useTime = 25;
            item.useAnimation = 25;
            item.UseSound = SoundID.Item15;
            item.shootSpeed = 9.5f;
            item.melee = true;
            item.alpha = 0;
            item.damage = 101;
            item.crit = 10;
            item.knockBack = 6;
            item.value = 150000;
            item.rare = 8;
            item.scale = 1.3f;
            item.autoReuse = true;
        }


        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
                Lighting.AddLight(new Vector2(player.position.X, player.position.Y), 0.6f, 0.6f, 0f);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("YellowLaserArray");
            float spread = 20f * 0.0174f;// 20 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
            float randomSpeed = Main.rand.NextFloat() * 0.15f + 1.075f;
            speedX = baseSpeed * randomSpeed * (float)Math.Sin(randomAngle);
            speedY = baseSpeed * randomSpeed * (float)Math.Cos(randomAngle);
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.YellowPhasesaber);
            recipe.AddIngredient(ItemID.Ectoplasm, 8);
            recipe.AddIngredient(ItemID.Keybrand);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}