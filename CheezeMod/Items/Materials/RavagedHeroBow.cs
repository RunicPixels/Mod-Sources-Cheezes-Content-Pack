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
			item.name = "Ravaged Hero Bow";
			item.width = 24;
			item.height = 22;
			item.maxStack = 999;
			AddTooltip("An ancient bow, it looks tarnished but it still has some useful parts.");
            item.value = 18000;
            item.rare = 8;
		}
	}
}