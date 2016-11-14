using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class HellstoneBolt : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Hellstone Bolt";
			item.width = 26;
			item.height = 26;
			item.maxStack = 999;
			AddTooltip("'Sure to give a mechanical advantage.'");
			item.value = 4000;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar);
            recipe.AddTile(16);
            recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}