using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Blocks
{
    public class DoubleStackedPearlstoneBlock : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Double Stacked Pearlstone Block";
            item.width = 16;
            item.height = 16;
            item.scale = 1.0f;
            item.maxStack = 999;
            AddTooltip("One of these contain " + Convert.ToString(Math.Pow(CheezeMod.stackedBlockNumber, 2)) + " Pearlstone Blocks.");
            item.value = CheezeMod.blockBaseValue * ((int)Math.Pow(CheezeMod.stackedBlockNumber, 2));
            item.rare = 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StackedPearlstoneBlock", CheezeMod.stackedBlockNumber);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}