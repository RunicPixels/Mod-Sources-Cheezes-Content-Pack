using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.NPCs
{
    public class Protopet : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Protopet";
            npc.displayName = "Protopet";
            npc.width = 46;
            npc.height = 50;
            npc.life = 34;
            npc.lifeMax = 34;
            npc.damage = 10;
            npc.defense = 5;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath48;
            npc.value = 150f;
            npc.scale = 0.7f;
            npc.knockBackResist = 0.6f;
            npc.aiStyle = 3;
            banner = npc.type;
            bannerItem = mod.ItemType("ProtopetBanner");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.SnowFlinx];
            aiType = NPCID.SnowFlinx;
            animationType = NPCID.SnowFlinx;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return (CheezeMod.NoBiomeNormalSpawn(spawnInfo)) && (spawnInfo.spawnTileY > Main.worldSurface - 50) && (spawnInfo.spawnTileY < CheezeMod.HellLayer - 200) ? 0.2f : 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ProtopetBelly"), 1f);
                for (int k = 0; k < 5; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/ProtopetArm"), 1f);
                }
                for (int k = 0; k < 3; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/ProtopetEye"), 1f);
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
            for (int i = 0; i < 8; i++) // For giving a 0-8 amount of Iron Bolt on drop.
            {
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IronBolt"), 1);
                }
            }
            if (Main.rand.Next(25) == 0)
            {
                int selection = Main.rand.Next(CheezeItem.ratchetTier1List.Length);
                string selectedWeapon = CheezeItem.ratchetTier1List[selection];
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(selectedWeapon), 1);
            }
            for (int i = 0; i < 6; i++) // For giving a 0-5 amount of Meteorite Bolt on drop.
            {
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MeteoriteBolt"), 1);
                }
            }
           } 
        }
    }
