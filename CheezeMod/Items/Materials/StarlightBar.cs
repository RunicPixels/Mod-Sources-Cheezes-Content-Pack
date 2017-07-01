using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;
using CheezeMod.Items;

namespace CheezeMod.Items.Materials
{
	public class StarlightBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 999;


            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 7500;
			item.rare = 1;
            item.consumable = true;
            item.createTile = mod.TileType("StarlightBar");
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Starlight Bar");
      Tooltip.SetDefault("It shines in the moonlight.\nOres can be found on Floating Islands.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("CheezeMod:GoldBars");
            recipe.AddRecipeGroup("CheezeMod:SilverBars", 2);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "StarlightOre", 3);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
