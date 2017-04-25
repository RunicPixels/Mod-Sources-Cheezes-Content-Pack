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
			item.name = "Twinkling Stone";
			item.width = 26;
			item.height = 22;
			item.maxStack = 999;
			AddTooltip("Sometimes dropped by Eyebats");
            item.value = 100;
			item.rare = 0;
		}
	}
}