using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class TwinklingStone : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 22;
			item.maxStack = 999;

            item.value = 100;
			item.rare = 0;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Twinkling Stone");
      Tooltip.SetDefault("Sometimes dropped by Eyebats");
    }

	}
}
