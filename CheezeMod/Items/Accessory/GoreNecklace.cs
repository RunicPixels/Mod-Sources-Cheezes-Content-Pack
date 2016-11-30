using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Accessory
{
	public class GoreNecklace : ModItem
	{
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Neck);
            return true;
        }
        public override void SetDefaults()
		{
			item.name = "Gore Necklace";
			item.width = 32;
			item.height = 32;
			item.toolTip = "What's HP?";
			item.toolTip2 = "Increases Max Health by 25, melee crit damage by 10%, and defense by 3.";
			item.value = 12500;
			item.rare = 2;
			item.accessory = true;
            item.defense = 3;
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