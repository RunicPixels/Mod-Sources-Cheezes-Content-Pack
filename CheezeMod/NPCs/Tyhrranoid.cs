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
    public class Tyhrranoid : ModNPC
    {
        public override void SetDefaults()
        {
            npc.width = 26;
            npc.height = 40;
            npc.life = 33;
            npc.lifeMax = 33;
            npc.damage = 10;
            npc.defense = 4;
            npc.HitSound = mod.GetLegacySoundSlot(SoundType.NPCHit, "Sounds/NPCHit/ThyrranoidHit");
            npc.DeathSound = mod.GetLegacySoundSlot(SoundType.NPCKilled, "Sounds/NPCKilled/ThyrranoidDie");
            npc.value = 150f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 3;
            banner = npc.type;
            bannerItem = mod.ItemType("TyhrranoidBanner");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
            aiType = NPCID.GoblinScout;
            animationType = NPCID.Zombie;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tyhrranoid");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return (CheezeMod.NoBiomeNormalSpawn(spawnInfo) && (Main.dayTime) && (spawnInfo.spawnTileY < CheezeMod.HellLayer - 400)) ? ((Main.hardMode) ? 0.05f : 0.105f) : 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Organic/ThyrranoidBelly"), 1f);
                for (int k = 0; k < 5; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Organic/ThyrranoidArm"), 1f);
                }
                for (int k = 0; k < 3; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Organic/ThyrranoidEye"), 1f);
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, (float)hitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }
        public override void NPCLoot()
        {
            for (int i = 0; i < 9; i++) // For giving a 0-8 amount of Iron Bolt on drop.
            {
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IronBolt"), 1);
                }
            }
            if (Main.rand.Next(60) == 0)
            {
                int selection = Main.rand.Next(CheezeItem.ratchetTier1List.Length);
                string selectedWeapon = CheezeItem.ratchetTier1List[selection];
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(selectedWeapon), 1);
            }
            if (Main.rand.Next(5) == 0)
            {
                for (int i = 0; i < 5; i++) // For giving a 0-4 amount of Meteorite Bolt on drop.
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MeteoriteBolt"), 1);
                    }
                }
            }
        }
    }
}
