using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Boomerangs
{
	public class Bonemerang : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.Bananarang);

			item.damage = 25;
			item.melee = true;
			item.width = 22;
			item.height = 42;


            item.maxStack = 2;
            item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 10000;
            item.rare = 2;
			item.shoot = mod.ProjectileType("Bonemerang");
			item.shootSpeed = 11f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bonemerang");
      Tooltip.SetDefault("It's ought to be used by some skull wearing monsters.\nCan stack up to 2 times.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 75);
            recipe.AddIngredient(ItemID.WoodenBoomerang);
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
