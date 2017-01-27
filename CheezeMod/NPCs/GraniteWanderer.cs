using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod.Items;

namespace CheezeMod.NPCs
{
    public class GraniteWanderer : ModNPC
    {
        private float attackCool = 0f;

        public override void SetDefaults()
        {
            npc.name = "GraniteWanderer";
            npc.displayName = "Granite Wanderer";
            npc.width = 18;
            npc.height = 40;
            npc.life = 64;
            npc.lifeMax = 64;
            npc.damage = 25;
            npc.defense = 18;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.value = 150f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 3;
            banner = npc.type;
            bannerItem = mod.ItemType("GraniteWandererBanner");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
            aiType = NPCID.PirateDeckhand;
            animationType = NPCID.Zombie;
            attackCool = 150f;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return (CheezeMod.NormalSpawn(spawnInfo)) && (spawnInfo.granite) ? 0.25f : 0f;
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (npc.localAI[0] == 0f)
            {
                int damage = npc.damage / 3;
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
                    if (Main.expertMode &&  Collision.CanHit(npc.position, npc.width, npc.height, player.position, player.width, player.height) && Math.Abs(player.Center.X - npc.Center.X) < 900 && Math.Abs(player.Center.Y - npc.Center.Y) < 900)
                    {
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta.X, delta.Y, mod.ProjectileType("BlueLaserNPC"), damage, 3f, Main.myPlayer);
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 12);
                        attackCool = 300f + 200f * (float)npc.life / (float)npc.lifeMax + (float)Main.rand.Next(200);
                        npc.netUpdate = true;
                    }
                    else
                    {
                        attackCool = Main.rand.NextFloat() * 60f + 30f;
                    }
                    
                    
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("GraniteDust"), 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Granite/GraniteHead"), 1f);
                for (int k = 0; k < 8; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Granite/GraniteArm"), 1f);
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("GraniteDust"), (float)hitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }
        public override void NPCLoot()
        {
                for (int i= 0; i < 6; i++) // For giving a 0-5 amount of Granite Shard on drop.
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteShard"), 1);
                    }
                }
            if (Main.rand.Next(30) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteRod"), 1);
            }
        }
    }
}
