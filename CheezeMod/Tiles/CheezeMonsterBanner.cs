using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CheezeMod.Tiles
{
	public class CheezeMonsterBanner : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 111;
			TileObjectData.addTile(Type);
			dustType = -1;
			disableSmartCursor = true;
			AddMapEntry(new Color(13, 88, 130), "Banner");
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			int style = frameX / 18;
			string item;
			switch (style)
			{
				case 0:
					item = "GraniteWandererBanner";
					break;
                case 1:
                    item = "TyhrranoidBanner";
                    break;
                case 2:
                    item = "RobonoidBanner";
                    break;
                case 3:
                    item = "ProtopetBanner";
                    break;
                case 4:
                    item = "BonefishBanner";
                    break;
                case 5:
                    item = "MoltenEyeBanner";
                    break;
                case 6:
                    item = "DragonEyeBanner";
                    break;
                case 7:
                    item = "EyebatBanner";
                    break;
                default:
					return;
			}
			Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType(item));
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.player[Main.myPlayer];
				int style = Main.tile[i, j].frameX / 18;
				string type;
				switch (style)
				{
                    case 0:
                        type = "GraniteWanderer";
                        break;
                    case 1:
                        type = "Tyhrranoid";
                        break;
                    case 2:
                        type = "Robonoid";
                        break;
                    case 3:
                        type = "Protopet";
                        break;
                    case 4:
                        type = "Bonefish";
                        break;
                    case 5:
                        type = "MoltenEye";
                        break;
                    case 6:
                        type = "DragonEye";
                        break;
                    case 7:
                        type = "Eyebat";
                        break;
                    default:
						return;
				}
				player.NPCBannerBuff[mod.NPCType(type)] = true;
				player.hasBanner = true;
			}
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
	}
}