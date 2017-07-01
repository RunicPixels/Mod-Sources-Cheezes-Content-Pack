using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Accessory
{
    [AutoloadEquip(EquipType.Neck)]
    public class GoreNecklace : ModItem
    {
        public override void SetDefaults()
		{

			item.width = 32;
			item.height = 32;


			item.value = 12500;
			item.rare = 2;
			item.accessory = true;
            item.defense = 3;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gore Necklace");
            Tooltip.SetDefault("What's HP?\nIncreases Max Health by 25, melee crit damage by 10%, and defense by 3.");
        }


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.statLifeMax2 += 25;
            ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).meleeCritMultiplier += 0.1f;

        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilkRopeCoil, 1);
            recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddTile(TileID.SkyMill);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
