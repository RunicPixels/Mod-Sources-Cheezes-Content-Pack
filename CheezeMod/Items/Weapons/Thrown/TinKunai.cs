using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class TinKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);

			item.damage = 9;
			item.thrown = true;
            item.noMelee = true;
			item.width = 10;
			item.height = 36;
            item.autoReuse = true;

            item.useTime = 23;
			item.useAnimation = 23;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 1800;
            item.rare = 0;
			item.shoot = mod.ProjectileType("TinKunai");
			item.shootSpeed = 12f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Tin Kunai");
      Tooltip.SetDefault("You can't be a true ninja without these.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TinBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
    }
}
