using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class GuardianEssence : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Guardian Essence";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("The spirit of the guardians from Madrigal");
			item.value = CheezeItem.guardianPrice / 10;
			item.rare = CheezeItem.guardianRarity - 1;
		}
	}
}