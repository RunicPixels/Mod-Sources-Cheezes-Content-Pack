using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Chat;

namespace CheezeMod.Tiles
{
    public class MegaCorpVendor : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            animationFrameHeight = 74;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("MegaCorpVendor");
            AddMapEntry(new Color(0, 40, 125), name);
            disableSmartCursor = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 64, mod.ItemType("MegaCorpVendor"));
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.frameX < 66)
            {
                r = 0.5f;
                g = 0.5f;
                b = 0.8f;
            }
        }
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter >= 10)
            {
                frame = (frame + 1) % 7;
                frameCounter = 0;
            }
        }
    }
}