using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class OrichalcumKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);

			item.damage = 44;
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
			item.shoot = mod.ProjectileType("OrichalcumKunai");
			item.shootSpeed = 17.5f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Orichalcum Kunai");
      Tooltip.SetDefault("It has a tag on its handle which reads 'Hana', it's from a far eastern place.\nIt has a 20% chance to summon a flower petal to attack your enemy on hit.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 30);
			recipe.AddRecipe();
		}
    }
}
