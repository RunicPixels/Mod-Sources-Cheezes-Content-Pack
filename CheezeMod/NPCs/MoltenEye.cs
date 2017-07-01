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
    public class MoltenEye : ModNPC
    {
        private float attackCool
        {
            get
            {
                return npc.ai[0];
            }
            set
            {
                npc.ai[0] = value;
            }
        }
        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 30;
            npc.scale = 1.2f;
            npc.life = 60;
            npc.lifeMax = 60;
            npc.damage = 40;
            npc.defense = 25;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 150f;
            npc.lavaImmune = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[39] = true;
            npc.buffImmune[31] = false;
            npc.knockBackResist = 0.9f;
            npc.aiStyle = 2;
            banner = npc.type;
            bannerItem = mod.ItemType("MoltenEyeBanner");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DemonEye];
            animationType = NPCID.DemonEye;
            attackCool = 200f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Molten Eye");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return (CheezeMod.NormalSpawn(spawnInfo)) && NPC.downedBoss2 && (spawnInfo.spawnTileY > CheezeMod.HellLayer) ? Main.hardMode ? 0.0325f : 0.0475f : 0f;
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            Lighting.AddLight(npc.position, 1f, 0.7f, 0.2f);
            if(Main.rand.Next(4) == 0) {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Fire, 2.5f * (float)npc.direction, -2.5f, 0, default(Color), 1.3f);
            }
            if (npc.localAI[0] == 0f)
            {
                int damage = npc.damage / 2;
                attackCool -= 1f;
                if (Main.netMode != 1 && attackCool <= 0f)
                {
                    Vector2 delta = player.Center - npc.Center;
                    float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                    if (magnitude > 0)
                    {
                        delta *= 15f / magnitude;
                    }
                    else
                    {
                        delta = new Vector2(0f, 15f);
                    }
                    if (Main.expertMode)
                    {
                        damage = (int)(damage / Main.expertDamage);
                    }
                    if (Main.expertMode && Math.Abs(player.Center.X - npc.Center.X) < 900 && Math.Abs(player.Center.Y - npc.Center.Y) < 900)
                    {
                        attackCool = 200f + 200f * (float)npc.life / (float)npc.lifeMax + (float)Main.rand.Next(200);
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.BurningSphere);
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
                    }
                    else
                    {
                        attackCool = Main.rand.NextFloat() * 60f;
                    }
                    npc.netUpdate = true;
                    base.AI();
                }
            }
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
                        Dust.NewDust(npc.position, npc.width, npc.height, DustID.Fire, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
                    }
                    pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    if (Main.rand.Next(3) >= 1)
                    {
                        Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Magmatic/MoltenTail"), 1f);
                    }
                    else
                    {
                        Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Magmatic/MoltenBody"), 1f);
                    }
                }
                for (int k = 0; k < 1; k++)
                {
                    pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Magmatic/MoltenEye"), 1f);
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 63, (float)hitDirection, -1f, 0, default(Color), 0.7f);
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
            if (Main.rand.Next(100) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlowerofFire, 1);
            }
            if (Main.rand.Next(120) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlumbersShirt, 1);
            }
            if (Main.rand.Next(120) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlumbersPants, 1);
            }
            if (Main.rand.Next(120) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlumbersHat, 1);
            }
            if (Main.rand.Next(12) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1);
            }
            else if (Main.rand.Next(5) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Lens, 1);
            }
            else if (Main.rand.Next(4) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TopazLens"), 1);
            }
            else if (Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RubyLens"), 1);
            }
            else if (Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AmethystLens"), 1);
            }
        }
    }
}
