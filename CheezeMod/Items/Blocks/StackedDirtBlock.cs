using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Blocks
{
	public class StackedDirtBlock : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Stacked Dirt Block";
			item.width = 16;
			item.height = 16;
            item.scale = 1.0f;
			item.maxStack = 999;
            AddTooltip("One of these contain " + Convert.ToString(CheezeMod.stackedBlockNumber) + " Dirt Blocks.");
            item.value = CheezeMod.blockBaseValue * CheezeMod.stackedBlockNumber;
            item.rare = 1;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, CheezeMod.stackedBlockNumber);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DoubleStackedDirtBlock");
            recipe.SetResult(this, CheezeMod.stackedBlockNumber);
            recipe.AddRecipe();
        }
    }
}