using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class FlameWing : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 14;
            item.scale = 1.1f;
			item.maxStack = 999;

			item.value = 5000;
			item.rare = 1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Flame Wing");
      Tooltip.SetDefault("Batwings, but then just really, really hot.");
    }

	}
}
