using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class LuminiteBolt : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 30;
			item.maxStack = 999;

			item.value = 18000;
			item.rare = 10;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Luminite Bolt");
      Tooltip.SetDefault("'This will add that final touch.'");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}
