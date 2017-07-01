using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class StarlightKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);

			item.damage = 15;
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
            item.value = 5000;
            item.rare = 1;
			item.shoot = mod.ProjectileType("StarlightKunai");
			item.shootSpeed = 13f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Starlight Kunai");
      Tooltip.SetDefault("It has a tag on its handle which reads 'Hoshi', it's from a far eastern place.\nIt has a 50% chance to summon an attacking star on enemy hit.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StarlightBar");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 27);
			recipe.AddRecipe();
		}
    }
}
