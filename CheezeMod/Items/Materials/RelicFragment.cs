using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
    public class RelicFragment : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 22;
            item.scale = 1.1f;
            item.maxStack = 999;
            item.value = 1400;
            item.rare = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Relic Fragment");
            Tooltip.SetDefault("Archeologists would go crazy about this, it seems to be made from marble.");
        }
    }
}