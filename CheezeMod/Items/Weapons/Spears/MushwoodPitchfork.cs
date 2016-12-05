using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Spears
{
	public class MushwoodPitchfork : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Mushwood Pitchfork";
			item.damage = 8;
			item.melee = true;
			item.width = 44;
			item.height = 44;
			item.scale = 1.1f;
			item.maxStack = 1;
			item.toolTip = "Is this towing the lands or are the lands towing this?";
			item.useTime = 50;
			item.useAnimation = 50;
			item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = 1000;
            item.rare = 0;
			item.shoot = mod.ProjectileType("MushwoodPitchfork");
			item.shootSpeed = 3f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"Mushwood", 10);
            recipe.AddTile(18);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}