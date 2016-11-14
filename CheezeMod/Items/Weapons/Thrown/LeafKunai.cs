using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class LeafKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);
			item.name = "Leaf Kunai";
			item.damage = 19;
			item.thrown = true;
            item.noMelee = true;
			item.width = 14;
			item.height = 36;
            item.autoReuse = true;
            item.toolTip = "Will inflict poison on your enemies.";
            item.useTime = 18;
			item.useAnimation = 18;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 2500;
            item.rare = 0;
			item.shoot = mod.ProjectileType("LeafKunai");
			item.shootSpeed = 15f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores, 2);
            recipe.AddIngredient(ItemID.Stinger);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 111);
			recipe.AddRecipe();
		}
    }
}