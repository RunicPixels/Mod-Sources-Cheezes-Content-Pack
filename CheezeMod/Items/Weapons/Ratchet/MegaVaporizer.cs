using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class MegaVaporizer : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Mega Vaporizer";
			item.damage = 84;
			item.ranged = true;
			item.width = 76;
            item.scale = 0.8f;
			item.height = 36;
			item.toolTip = "Shoots a piercing puple explosive beam, right click to zoom.";
            item.toolTip2 = "Originally from Ratchet and Clank: Going Commando.";
            item.useTime = 40;
            item.useAnimation = 40;
			item.useStyle = 5;
            item.crit = 25;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 300000;
            item.rare = CheezeItem.ratchetRarity[2];
            item.UseSound = SoundID.Item40;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 30f;
			item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Vaporizer");
            recipe.AddIngredient(null, "HallowedBolt", 50);
            recipe.AddIngredient(ItemID.SoulofSight, 2);
            recipe.AddIngredient(null, "AmethystLens");
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
            type = mod.ProjectileType("MegaVaporizer");
            return true;
        }
    }
}