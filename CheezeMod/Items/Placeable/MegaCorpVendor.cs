using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Placeable
{
	public class MegaCorpVendor : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 52;
			item.height = 52;
			item.maxStack = 99;

			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 75000;
			item.createTile = mod.TileType("MegaCorpVendor");
            item.rare = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("MegaCorp Vendor");
      Tooltip.SetDefault("Build weapons from Ratchet & Clank here.");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 5);
            recipe.AddIngredient(ItemID.StoneBlock, 25);
            recipe.AddRecipeGroup("CheezeMod:SilverBars", 3);
            recipe.AddIngredient(null, "IronBolt", 50);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}
