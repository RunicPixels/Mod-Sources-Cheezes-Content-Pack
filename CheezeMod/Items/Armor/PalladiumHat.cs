using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumHat : ModItem
	{
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.PalladiumBreastplate && legs.type == ItemID.PalladiumLeggings;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Greatly increases life regeneration after striking an enemy.";
            player.onHitRegen = true;
        }
        public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;


            item.value = 10000;
			item.rare = 4;
			item.defense = 7;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Palladium Hat");
      Tooltip.SetDefault("Good for people that throw things.\n30% inceased throwing velocity, 10% increased throwing damage");
    }


        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.1f;
            player.thrownVelocity += 0.3f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 12);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
