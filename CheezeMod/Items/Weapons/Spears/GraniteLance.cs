using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Spears
{
	public class GraniteLance : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Granite Lance";
			item.damage = 13;
			item.melee = true;
			item.width = 44;
			item.height = 44;
			item.scale = 1.1f;
			item.maxStack = 1;
			item.toolTip = "Gives a player 2 seconds of endurance on hit";
			item.useTime = 40;
			item.useAnimation = 40;
			item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = 10000;
            item.rare = 1;
			item.shoot = mod.ProjectileType("GraniteLance");
			item.shootSpeed = 5f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GraniteShard", 40);
            recipe.AddIngredient(ItemID.GraniteBlock, 20);
            recipe.AddTile(16);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}