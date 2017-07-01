using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Spears
{
	public class LivingWoodPitchfork : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 8;
			item.melee = true;
			item.width = 44;
			item.height = 44;
			item.scale = 1.1f;
			item.maxStack = 1;

			item.useTime = 40;
			item.useAnimation = 40;
			item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = 5000;
            item.rare = 0;
			item.shoot = mod.ProjectileType("LivingWoodPitchfork");
			item.shootSpeed = 4f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Living Wood Pitchfork");
      Tooltip.SetDefault("There's leaves growing on this.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("CheezeMod:AnyWood", 10);
            recipe.AddTile(304);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
