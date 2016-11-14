using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Armor
{
	public class StarlightLeggings : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Legs);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Starlight Leggings";
			item.width = 18;
			item.height = 18;
			item.toolTip = "It helps you to feel magical, light and strong.";
            item.toolTip2 = "+3.5% Melee and Magic damage as well as movement speed.";
            item.value = 10000;
			item.rare = 2;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
            player.magicDamage += 0.035f;
            player.meleeDamage += 0.035f;
            player.moveSpeed += 0.035f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather, 4);
            recipe.AddIngredient(mod, "StarlightBar", 15);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}