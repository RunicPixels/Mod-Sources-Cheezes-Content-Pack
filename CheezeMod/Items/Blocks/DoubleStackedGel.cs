using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Blocks
{
    public class DoubleStackedGel : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Double Stacked Gel";
            item.width = 16;
            item.height = 16;
            item.scale = 1.0f;
            item.maxStack = 999;
            AddTooltip("One of these contain " + Convert.ToString(Math.Pow(CheezeMod.stackedBlockNumber, 2)) + " Gel.");
            item.value = CheezeMod.blockBaseValue * ((int)Math.Pow(CheezeMod.stackedBlockNumber, 2));
            item.rare = 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StackedGel", CheezeMod.stackedBlockNumber);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}