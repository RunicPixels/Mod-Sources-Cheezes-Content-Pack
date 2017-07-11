using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class UltraVaporizer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 321;
			item.ranged = true;
			item.width = 76;
            item.scale = 0.8f;
			item.height = 36;


            item.useTime = 30;
            item.useAnimation = 30;
			item.useStyle = 5;
            item.crit = 25;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 1000000;
            item.rare = CheezeItem.ratchetRarity[3];
            item.UseSound = SoundID.Item40;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 30f;
			item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ultra Vaporizer");
      Tooltip.SetDefault("Shoots a vaporizing white laser, right click to zoom.\nOriginally from Ratchet and Clank: Going Commando.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MegaVaporizer");
            recipe.AddIngredient(null, "LuminiteBolt", 50);
            recipe.AddIngredient(null, "Antimatter", 2);
            recipe.AddIngredient(null, "DiamondLens");
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                player.scope = true;
            }
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("UltraVaporizer");
            return true;
        }
    }
}
