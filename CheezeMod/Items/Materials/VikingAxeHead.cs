using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
    public class VikingAxeHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 18;
            item.maxStack = 999;

            item.value = 1400;
            item.rare = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Viking Axe Head");
            Tooltip.SetDefault("Dropped by Undead Vikings, used to create a Viking Axe");
        }

    }
}
