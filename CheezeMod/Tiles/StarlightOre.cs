using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Tiles
{
	public class StarlightOre : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            soundType = 21;
            minPick = 55;
			drop = mod.ItemType("StarlightOre");
			AddMapEntry(new Color(255, 255, 0));
		}
	}
}