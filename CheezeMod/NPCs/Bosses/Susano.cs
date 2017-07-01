using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.World;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod.Items;

namespace CheezeMod.NPCs.Bosses
{
    public class Susano : ModNPC
    {
        public override void SetDefaults()
        {
            //npc.CloneDefaults(NPCID.Piranha);
            npc.width = 138;
            npc.height = 156;
            npc.life = 20000;
            npc.lifeMax = 20000;
            npc.knockBackResist = 0;
            npc.damage = 35;
            npc.defense = 45;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.value = 2000f;
            npc.aiStyle = 11;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
            npc.netAlways = true;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.SkeletronHead];
            animationType = NPCID.SkeletronHead;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Susano");
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
        public override void AI()
        {
            npc.velocity *= 1.01f;
            base.AI();
        }
    }
}
