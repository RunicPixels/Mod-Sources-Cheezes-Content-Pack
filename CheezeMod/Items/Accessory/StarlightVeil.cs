using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Accessory
{
	public class StarlightVeil : ModItem
	{
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Neck);
            return true;
        }
        public override void SetDefaults()
		{
			item.name = "Starlight Veil";
			item.width = 28;
			item.height = 28;
			item.toolTip = "Causes stars to fall and increases length of invincibility after taking damage.";
			item.toolTip2 = "Increases Magic, Melee damage and maximum movement speed by 6%";
			item.value = 200000;
			item.rare = 7;
			item.accessory = true;
			item.defense = 3;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.runAcceleration += 0.06f;
            player.maxRunSpeed += 0.06f;
            player.magicDamage += 0.06f;
            player.meleeDamage += 0.06f;
            player.starCloak = true;
            player.longInvince = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "StarlightNecklace");
            recipe.AddIngredient(ItemID.StarVeil);
            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}