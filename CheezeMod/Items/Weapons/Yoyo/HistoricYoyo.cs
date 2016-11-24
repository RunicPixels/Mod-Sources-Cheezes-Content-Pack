using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Yoyo
{
	public class HistoricYoyo : ModItem
	{
		public override void SetDefaults()
		{
            item.name = "Historic Yo-Yo";
			item.damage = 42;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.toolTip = "A yoyo that is an historic artifact of Madrigal. \n+5% Critical Chance. \n+31% Increased Critical Damage.\n Inflics Dryad's Bane on enemy hit.";
			item.knockBack = 5f;
            item.useTime = 10;
            item.useAnimation = 10;
            item.autoReuse = true;
			item.useSound = 1;
            item.useStyle = 5;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
            item.value = CheezeItem.historicPrice;
            item.rare = CheezeItem.historicRarity;
            item.crit = 15;
            item.shoot = mod.ProjectileType("HistoricYoyo");
            item.channel = true;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "HistoricEssence", 5);
            recipe.AddIngredient(ItemID.Cascade);
            recipe.AddTile(18);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.31f;
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).flyffhistoric = true; // Dryad debuff on enemy for 1 sec.
            }
        }
    }
}