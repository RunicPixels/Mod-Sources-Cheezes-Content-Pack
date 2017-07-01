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

			item.width = 26;
			item.height = 22;
			item.maxStack = 999;

			item.value = CheezeItem.angelPrice / 10;
			item.rare = CheezeItem.angelRarity-1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Angel Essence");
      Tooltip.SetDefault("An angelic relic from Madrigal");
    }

	}
}
