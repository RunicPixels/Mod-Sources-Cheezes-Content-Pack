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
			item.name = "Flame Wing";
			item.width = 16;
			item.height = 14;
            item.scale = 1.1f;
			item.maxStack = 999;
			AddTooltip("Batwings, but then just really, really hot.");
			item.value = 5000;
			item.rare = 1;
		}
	}
}