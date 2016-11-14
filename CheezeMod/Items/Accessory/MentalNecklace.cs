using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Accessory
{
	public class MentalNecklace : ModItem
	{
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Neck);
            return true;
        }
        public override void SetDefaults()
		{
			item.name = "Mental Necklace";
			item.width = 32;
			item.height = 32;
			item.toolTip = "What's MP?";
			item.toolTip2 = "Increases Max Mana by 25, magical crit damage by 5% and max summons by 1.";
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.statManaMax2 += 25;
            player.maxMinions += 1;
            ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).magicCritMultiplier += 0.05f;

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