using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class HeavyLancer : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Heavy Lancer";
			item.damage = 14;
			item.ranged = true;
			item.width = 64;
			item.height = 30;
            item.scale = 0.8f;
            item.toolTip = "'My barrel runs hot!', 22% Chance not to consume ammo. Converts normal bullets into Heavy Lancer shots.";
            item.toolTip2 = "Originally from Ratchet and Clank: Going Commando.";
            item.useTime = 9;
            item.useAnimation = 9;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 150000;
			item.rare = 3;
			item.useSound = 11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 7f;
			item.useAmmo = ProjectileID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Lancer");
            recipe.AddIngredient(null, "HellstoneBolt", 50);
            recipe.AddIngredient(null, "FlameWing", 15);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 4.5f * 0.0174f; // 5.5 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
            speedX = baseSpeed * (float)Math.Sin(randomAngle);
            speedY = baseSpeed * (float)Math.Cos(randomAngle);
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("HeavyLancer");
                damage *= (int)1.1;
            }
            return true;
        }

        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(9) < 7; // 22.22%
        }
    }
}