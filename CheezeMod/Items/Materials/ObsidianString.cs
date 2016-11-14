using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
    public class ObsidianString : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Obsidian String";
            item.width = 16;
            item.height = 14;
            item.scale = 1.1f;
            item.maxStack = 999;
            AddTooltip("For when your bow just runs too hot.");
            item.value = 10000;
            item.rare = 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WhiteString);
            recipe.AddIngredient(ItemID.Obsidian, 20);
            recipe.AddTile(77);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}