using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class AdamantiteKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);

			item.damage = 50;
			item.thrown = true;
            item.noMelee = true;
			item.width = 18;
			item.height = 38;
            item.autoReuse = true;


            item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 10000;
            item.rare = 4;
			item.shoot = mod.ProjectileType("AdamantiteKunai");
			item.shootSpeed = 20f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Adamantite Kunai");
      Tooltip.SetDefault("It has a tag on its handle which reads 'Gundan', it's from a far eastern place.\nIt has a 10% chance to grant ironskin effect for 4 seconds and endurance effect for 1 second on the player on enemy hit.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 35);
			recipe.AddRecipe();
		}
    }
}
