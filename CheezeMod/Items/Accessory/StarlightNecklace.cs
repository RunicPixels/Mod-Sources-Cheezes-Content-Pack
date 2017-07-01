using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Accessory
{
    [AutoloadEquip(EquipType.Neck)]
    public class StarlightNecklace : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 28;
            item.height = 28;


            item.value = 10000;
            item.rare = 1;
            item.accessory = true;
            item.defense = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starlight Necklace");
            Tooltip.SetDefault("It's filled with star power.\nIncreases Magic, Melee damage and maximum movement speed by 5%");
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
