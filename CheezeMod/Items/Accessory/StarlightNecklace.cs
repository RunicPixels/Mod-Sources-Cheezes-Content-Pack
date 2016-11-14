using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Accessory
{
	public class StarlightNecklace : ModItem
	{
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Neck);
            return true;
        }
        public override void SetDefaults()
		{
			item.name = "Starlight Necklace";
			item.width = 28;
			item.height = 28;
			item.toolTip = "It's filled with star power.";
			item.toolTip2 = "Increases Magic, Melee damage and maximum movement speed by 5%";
			item.value = 10000;
			item.rare = 1;
			item.accessory = true;
			item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.runAcceleration += 0.05f;
            player.maxRunSpeed += 0.05f;
            player.magicDamage += 0.05f;
            player.meleeDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "StarlightBar", 12);
            recipe.AddIngredient(ItemID.Shackle, 1);
            recipe.AddTile(TileID.SkyMill);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}