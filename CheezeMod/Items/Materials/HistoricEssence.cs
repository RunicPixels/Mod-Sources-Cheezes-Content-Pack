using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class HistoricEssence : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Historic Essence";
			item.width = 26;
			item.height = 22;
			item.maxStack = 999;
			AddTooltip("An historic relic from Madrigal");
			item.value = 6000;
			item.rare = 2;
		}
	}
}