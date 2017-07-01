using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Spears
{
	public class WoodenPitchfork : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 5;
			item.melee = true;
			item.width = 44;
			item.height = 44;
			item.scale = 1.1f;
			item.maxStack = 1;

			item.useTime = 50;
			item.useAnimation = 50;
			item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = 1000;
            item.rare = 0;
			item.shoot = mod.ProjectileType("WoodenPitchfork");
			item.shootSpeed = 3f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Wooden Pitchfork");
      Tooltip.SetDefault("Beside towing lands, this is also useful for defending yourself.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("CheezeMod:AnyWood", 10);
            recipe.AddTile(18);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
