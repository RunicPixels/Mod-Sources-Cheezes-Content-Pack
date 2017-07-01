using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.World;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod.Items;

namespace CheezeMod.NPCs
{
    public class Eyebat : ModNPC
    {
        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 30;
            npc.scale = 1f;
            npc.life = 20;
            npc.lifeMax = 20;
            npc.damage = 10;
            npc.defense = 2;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.buffImmune[20] = true;
            npc.buffImmune[31] = false;
            npc.knockBackResist = 0.9f;
            npc.aiStyle = 2;
            banner = npc.type;
            bannerItem = mod.ItemType("EyebatBanner");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GiantBat];
            animationType = NPCID.GiantBat;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eyebat");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            return (CheezeMod.NoBiomeNormalSpawn(spawnInfo)) && (Main.dayTime) && (spawnInfo.spawnTileY < CheezeMod.HellLayer - 400) ? ((Main.hardMode) ? 0.045f : 0.095f) : 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Vector2 pos;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                    }
                    pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    if (Main.rand.Next(3) >= 1)
                    {
                        Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Organic/EyebatTail"), 1f);
                    }
                    else
                    {
                        Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Organic/EyebatBody"), 1f);
                    }
                }
                for (int k = 0; k < 1; k++)
                {
                    pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Organic/EyebatWing"), 1f);
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Grass, (float)hitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(8) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TwinklingStone"), Main.rand.Next(5));
            }
            if (Main.rand.Next(40) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1);
            }
            if (Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Lens, 1);
            }
            else if (Main.rand.Next(18) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RubyLens"), 1);
            }
        }
    }
}
