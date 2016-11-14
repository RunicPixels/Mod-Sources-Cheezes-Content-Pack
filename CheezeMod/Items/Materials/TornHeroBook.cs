using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class TornHeroBook : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Torn Hero Book";
			item.width = 24;
			item.height = 22;
			item.maxStack = 999;
			AddTooltip("This was a spell used by mages of the old times.");
            item.value = 18000;
            item.rare = 8;
		}
	}
}