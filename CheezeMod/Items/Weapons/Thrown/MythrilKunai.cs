using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class MythrilKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);
			item.name = "Mythril Kunai";
			item.damage = 42;
			item.thrown = true;
            item.noMelee = true;
			item.width = 18;
			item.height = 38;
            item.autoReuse = true;
            item.toolTip = "It has a tag on its handle which reads 'Fantaji', it's from a far eastern place.";
            item.toolTip2 = "It has a 10% chance to grant rage effect for 3 seconds on the player on enemy hit.";
            item.useTime = 19;
			item.useAnimation = 19;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 10000;
            item.rare = 4;
			item.shoot = mod.ProjectileType("MythrilKunai");
			item.shootSpeed = 18f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 30);
			recipe.AddRecipe();
		}
    }
}