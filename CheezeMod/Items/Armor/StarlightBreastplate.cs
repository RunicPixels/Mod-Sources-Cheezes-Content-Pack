using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class StarlightBreastplate : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;


            item.value = 10000;
            item.rare = 2;
            item.defense = 6;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starlight Breastplate");
            Tooltip.SetDefault("It looks fancy.\n+15 max mana, 2.5% Melee and Magic damage.");
        }


        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 15;
            player.magicDamage += 0.025f;
            player.meleeDamage += 0.025f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather, 4);
            recipe.AddIngredient(mod, "StarlightBar", 18);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}