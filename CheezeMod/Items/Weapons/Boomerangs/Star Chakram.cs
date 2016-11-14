using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Boomerangs
{
	public class StarChakram : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThornChakram);
			item.name = "Star Chakram";
			item.damage = 24;
			item.melee = true;
			item.width = 28;
			item.height = 28;
            item.scale = 0.7f;
            item.autoReuse = true;
            item.toolTip = "Calls Stars on hit.";
            item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 5f;
			item.useSound = 1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 10000;
            item.rare = 2;
			item.shoot = mod.ProjectileType("StarChakram");
			item.shootSpeed = 11f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "StarlightBar", 12);
            recipe.AddIngredient(ItemID.Feather, 5);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool CanUseItem(Player player)
        {
            int stackCounter = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    stackCounter++;
                }
            }
            if (stackCounter >= item.stack)
            {
                return false;
            }
            else return true;
        }

    }
}