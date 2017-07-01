using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class IronKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);

			item.damage = 10;
			item.thrown = true;
            item.noMelee = true;
			item.width = 14;
			item.height = 36;
            item.autoReuse = true;

            item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 2000;
            item.rare = 0;
			item.shoot = mod.ProjectileType("IronKunai");
			item.shootSpeed = 13f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Iron Kunai");
      Tooltip.SetDefault("You can't be a true ninja without these.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
    }
}
