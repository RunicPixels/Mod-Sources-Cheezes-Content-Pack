using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Accessory
{
    [AutoloadEquip(EquipType.Neck)]
    public class MentalNecklace : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;


            item.value = 10000;
            item.rare = 2;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mental Necklace");
            Tooltip.SetDefault("What's MP?\nIncreases Max Mana by 25, magical crit damage by 5% and max summons by 1.");
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
