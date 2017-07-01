using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class HallowedBolt : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 30;
			item.maxStack = 999;

			item.value = 9000;
			item.rare = 5;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Hallowed Bolt");
      Tooltip.SetDefault("'It seems shiny.'");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}
