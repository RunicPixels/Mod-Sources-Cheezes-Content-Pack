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
			item.name = "Relic Fragment";
			item.width = 20;
			item.height = 22;
            item.scale = 1.1f;
			item.maxStack = 999;
			AddTooltip("Archeologists would go crazy about this, it seems to be made from marble.");
			item.value = 1400;
			item.rare = 1;
		}
	}
}