using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class GraniteShard : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Granite Shard";
			item.width = 16;
			item.height = 14;
            item.scale = 1.1f;
			item.maxStack = 999;
			AddTooltip("This seems pretty durable.");
			item.value = 1400;
			item.rare = 1;
		}
	}
}