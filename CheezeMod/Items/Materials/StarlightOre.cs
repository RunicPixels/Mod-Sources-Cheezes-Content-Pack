using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class StarlightOre : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 12;
			item.height = 12;
			item.maxStack = 999;

			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
            item.value = 2500;
            item.rare = 1;
			item.consumable = true;
			item.createTile = mod.TileType("StarlightOre");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Starlight Ore");
      Tooltip.SetDefault("It feels pretty warm");
    }

	}
}
