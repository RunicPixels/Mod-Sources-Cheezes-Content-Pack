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
    public class Robonoid : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Robonoid";
            npc.displayName = "Robonoid";
            npc.width = 26;
            npc.height = 40;
            npc.life = 60;
            npc.lifeMax = 60;
            npc.damage = 49;
            npc.defense = 35;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = mod.GetLegacySoundSlot(SoundType.NPCKilled, "Sounds/NPCKilled/ThyrranoidDie");
            npc.value = 450f;
            npc.knockBackResist = 0.35f;
            npc.aiStyle = 3;
            banner = npc.type;
            bannerItem = mod.ItemType("RobonoidBanner");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
            aiType = NPCID.GoblinScout;
            animationType = NPCID.Zombie;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return (CheezeMod.NoBiomeNormalSpawn(spawnInfo)) && (Main.dayTime) && (Main.hardMode) && (spawnInfo.spawnTileY < Main.rockLayer) ? 0.2f : 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Mechanic/RobonoidBelly"), 1f);
                for (int k = 0; k < 5; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Mechanic/RobonoidArm"), 1f);
                }
                for (int k = 0; k < 3; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Mechanic/RobonoidEye"), 1f);
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 226, (float)hitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }
        public override void NPCLoot()
        {
            for (int i = 0; i < 9; i++) // For giving a 0-8 amount of Iron Bolt on drop.
            {
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HellstoneBolt"), 1);
                }
            }
            if (Main.rand.Next(10) == 0)
            {
                int selection = Main.rand.Next(CheezeItem.ratchetTier2List.Length);
                string selectedWeapon = CheezeItem.ratchetTier2List[selection];
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(selectedWeapon), 1);
            }
        }
    }
}
