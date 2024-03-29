using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Blocks
{
	public class DoubleStackedDirtBlock : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 16;
            item.scale = 1.0f;
			item.maxStack = 999;

            item.value = CheezeMod.blockBaseValue * ((int)Math.Pow(CheezeMod.stackedBlockNumber, 2));
            item.rare = 2;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Double Stacked Dirt Block");
      Tooltip.SetDefault("One of these contain ");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StackedDirtBlock", CheezeMod.stackedBlockNumber);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
