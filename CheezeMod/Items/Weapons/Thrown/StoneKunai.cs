using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class StoneKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);

			item.damage = 8;
			item.thrown = true;
            item.noMelee = true;
			item.width = 10;
			item.height = 36;
            item.autoReuse = true;

            item.useTime = 28;
			item.useAnimation = 28;
			item.knockBack = 1.2f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 500;
            item.rare = 0;
			item.shoot = mod.ProjectileType("StoneKunai");
			item.shootSpeed = 9f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Stone Kunai");
      Tooltip.SetDefault("You can't be a true ninja without these.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 15);
			recipe.AddRecipe();
		}
    }
}
