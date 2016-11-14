using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class CobaltKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);
			item.name = "Cobalt Kunai";
			item.damage = 37;
			item.thrown = true;
            item.noMelee = true;
			item.width = 18;
			item.height = 38;
            item.autoReuse = true;
            item.toolTip = "It has a tag on its handle which reads 'Umi', it's from a far eastern place.";
            item.toolTip2 = "It has a 10% chance to grant swiftness effect for 5 seconds on the player on enemy hit.";
            item.useTime = 19;
			item.useAnimation = 19;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 10000;
            item.rare = 4;
			item.shoot = mod.ProjectileType("CobaltKunai");
			item.shootSpeed = 17f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 27);
			recipe.AddRecipe();
		}
    }
}