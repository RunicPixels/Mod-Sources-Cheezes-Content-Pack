using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Boomerangs
{
	public class Kaboomerang : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.Bananarang);
			item.name = "Kaboomerang";
			item.damage = 69;
			item.melee = true;
			item.width = 36;
			item.height = 36;
			item.scale = 1.1f;
			item.toolTip = "A true lihzahrd has some explosive instincts.";
            item.toolTip2 = "Explodes on hit, can stack up to 2 times.";
            item.maxStack = 2;
            item.useTime = 22;
			item.useAnimation = 22;
			item.knockBack = 10f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 10000;
            item.rare = 7;
			item.shoot = mod.ProjectileType("Kaboomerang");
			item.shootSpeed = 12f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 5);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddTile(18);
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