using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
    public class IronBolt : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Iron Bolt";
            item.width = 26;
            item.height = 26;
            item.maxStack = 999;
            AddTooltip("Used for crafting mechanical weapons.");
            item.value = 800;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CheezeMod:IronBars");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}