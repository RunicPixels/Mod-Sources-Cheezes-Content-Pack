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

            item.width = 26;
            item.height = 26;
            item.maxStack = 999;

            item.value = 1400;
            item.rare = 1;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Meteorite Bolt");
      Tooltip.SetDefault("Used for crafting mechanical weapons.");
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
