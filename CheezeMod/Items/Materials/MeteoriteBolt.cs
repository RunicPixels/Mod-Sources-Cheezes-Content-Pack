using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
    public class MeteoriteBolt : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Meteorite Bolt";
            item.width = 26;
            item.height = 26;
            item.maxStack = 999;
            AddTooltip("Used for crafting mechanical weapons.");
            item.value = 1400;
            item.rare = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar);
            recipe.AddTile(16);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}