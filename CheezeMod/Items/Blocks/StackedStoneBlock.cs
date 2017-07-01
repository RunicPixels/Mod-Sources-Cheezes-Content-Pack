using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Blocks
{
    public class StackedStoneBlock : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 16;
            item.height = 16;
            item.scale = 1.0f;
            item.maxStack = 999;

            item.value = CheezeMod.blockBaseValue * CheezeMod.stackedBlockNumber; ;
            item.rare = 1;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Stacked Stone Block");
      Tooltip.SetDefault("One of these contain ");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, CheezeMod.stackedBlockNumber);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DoubleStackedStoneBlock");
            recipe.SetResult(this, CheezeMod.stackedBlockNumber);
            recipe.AddRecipe();
        }
    }
}
