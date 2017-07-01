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

			item.width = 26;
			item.height = 26;
			item.maxStack = 999;

			item.value = 4000;
			item.rare = 1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Hellstone Bolt");
      Tooltip.SetDefault("'Sure to give a mechanical advantage.'");
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
