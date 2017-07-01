using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class PalladiumKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);

			item.damage = 38;
			item.thrown = true;
            item.noMelee = true;
			item.width = 18;
			item.height = 38;
            item.autoReuse = true;


            item.useTime = 19;
			item.useAnimation = 19;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 10000;
            item.rare = 4;
			item.shoot = mod.ProjectileType("PalladiumKunai");
			item.shootSpeed = 16.5f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Palladium Kunai");
      Tooltip.SetDefault("It has a tag on its handle which reads 'Kazan', it's from a far eastern place.\nIt has a 10% chance to grant rapid healing effect for 5 seconds on the player on enemy hit. (10 seconds when having palladium armor equiped)");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 27);
			recipe.AddRecipe();
		}
    }
}
