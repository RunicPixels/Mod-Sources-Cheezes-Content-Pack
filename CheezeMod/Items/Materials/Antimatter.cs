using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
    public class Antimatter : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 999;
            item.value = 500000;
            item.rare = 9;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antimatter");
            Tooltip.SetDefault("It doesn't matter.\nSold by certain Martian Traders.");
        }

    }
}
