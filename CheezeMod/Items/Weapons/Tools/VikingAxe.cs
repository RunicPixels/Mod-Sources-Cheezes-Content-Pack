using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Tools
{
	public class VikingAxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.melee = true;
			item.width = 38;
			item.height = 34;

			item.useTime = 26;
			item.scale = 1.33f;
			item.useAnimation = 26;
			item.axe = 10;
			item.useStyle = 1;
			item.knockBack = 4.5f;
			item.value = 2400;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Viking Axe");
			Tooltip.SetDefault("It's a Skeggøx type axe, which means 'bearded axe'.");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "VikingAxeHead", 1);
			recipe.AddIngredient(ItemID.BorealWood, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
