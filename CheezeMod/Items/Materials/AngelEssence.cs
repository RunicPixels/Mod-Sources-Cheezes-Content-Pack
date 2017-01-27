using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class AngelEssence : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Angel Essence";
			item.width = 26;
			item.height = 22;
			item.maxStack = 999;
			AddTooltip("An angelic relic from Madrigal");
			item.value = CheezeItem.angelPrice / 10;
			item.rare = CheezeItem.angelRarity-1;
		}
	}
}