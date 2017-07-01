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

            item.width = 16;
            item.height = 14;
            item.scale = 1.1f;
            item.maxStack = 999;

            item.value = 10000;
            item.rare = 3;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Obsidian String");
      Tooltip.SetDefault("For when your bow just runs too hot.");
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
