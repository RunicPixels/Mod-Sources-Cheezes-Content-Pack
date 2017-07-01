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
    public class Bonefish : ModNPC
    {
        public override void SetDefaults()
        {
            //npc.CloneDefaults(NPCID.Piranha);
            npc.width = 26;
            npc.height = 20;
            npc.life = 36;
            npc.lifeMax = 36;
            npc.damage = 35;
            npc.defense = 5;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 200f;
            npc.aiStyle = 16;
            npc.noGravity = true;
            aiType = NPCID.Piranha;
            banner = npc.type;
            bannerItem = mod.ItemType("BonefishBanner");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Piranha];
            animationType = NPCID.Piranha;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bonefish");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return (spawnInfo.water && spawnInfo.player.ZoneDungeon) ? 1f : 0.0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 5; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 121, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Bone/BoneTail"), 1f);
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Bone/BoneFishHead"), 1f);
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 121, (float)hitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(50) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Bonemerang"), 1);
            }
            if (Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GoldenKey"), 1);
            }
            if (Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hook, 1);
            }
            if (Main.rand.Next(50) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Compass, 1);
            }
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bone, Main.rand.Next(5));
        }
    }
}
