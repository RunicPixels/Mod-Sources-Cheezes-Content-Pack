using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class BoneKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);
			item.name = "Bone Kunai";
			item.damage = 25;
			item.thrown = true;
            item.noMelee = true;
			item.width = 18;
			item.height = 40;
            item.autoReuse = true;
            item.toolTip = "Undead ninjas are a thing.";
            item.useTime = 18;
			item.useAnimation = 18;
			item.knockBack = 2.2f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 3000;
            item.rare = 1;
			item.shoot = mod.ProjectileType("BoneKunai");
			item.shootSpeed = 15f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 222);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 111);
			recipe.AddRecipe();
            recipe.AddIngredient(ItemID.Bone, 22);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 11);
            recipe.AddRecipe();
            recipe.AddIngredient(ItemID.Bone, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}