using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
    public class VikingHammerHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;
            item.maxStack = 999;

            item.value = 1400;
            item.rare = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Viking Hammer Head");
            Tooltip.SetDefault("Dropped by Undead Vikings, used to create a Viking Hammer");
        }

    }
}
