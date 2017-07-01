using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class Mushwood : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 24;
			item.maxStack = 999;

			item.value = 500;
			item.rare = 1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mushwood");
      Tooltip.SetDefault("There's things growing on this.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CheezeMod:AnyWood");
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddTile(18);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
