using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class RavagedHeroBow : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 22;
			item.maxStack = 999;

            item.value = 18000;
            item.rare = 8;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ravaged Hero Bow");
      Tooltip.SetDefault("An ancient bow, it looks tarnished but it still has some useful parts.");
    }

	}
}
