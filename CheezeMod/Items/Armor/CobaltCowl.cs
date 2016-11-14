using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Armor
{
	public class CobaltCowl : ModItem
	{
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "33% chance not to consume thrown item.";
            player.thrownCost33 = true;
        }

        public override void ArmorSetShadows(Player player, ref bool longTrail, ref bool smallPulse, ref bool largePulse, ref bool shortTrail)
        {
            longTrail = true;
            base.ArmorSetShadows(player, ref longTrail, ref smallPulse, ref largePulse, ref shortTrail);
        }
        public override void SetDefaults()
		{
			item.name = "Cobalt Cowl";
			item.width = 18;
			item.height = 18;
			item.toolTip = "Good for people that throw things.";
            item.toolTip2 = "10% inceased movement speed, 8% increased throwing damage";
            item.value = 10000;
			item.rare = 4;
			item.defense = 5;
		}

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.08f;
            player.moveSpeed += 0.10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 12);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}