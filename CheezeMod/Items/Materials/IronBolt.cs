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

            item.width = 26;
            item.height = 26;
            item.maxStack = 999;

            item.value = 800;
            item.rare = 0;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Iron Bolt");
      Tooltip.SetDefault("Used for crafting mechanical weapons.");
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
