using Microsoft.Xna.Framework;
using System.Linq;
using CheezeMod;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.NPCs
{
    public class CheezeGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity // To Allow Non-Instanced and Non-Static Variables
        {
            get
            {
                return true;
            }
        }

        public bool radiation = false;
        public bool extremeRadiation = false;
        public bool downfall = false;
        public bool angelsBane = false;
        public bool sellFlare = false;


        // ====== // Custom Functions \\ ====== \\
        #region CustomFunctions
        private static int FlyffMax()
        {
            if (Main.expertMode) return 4 + Main.rand.Next(4);
            else return 3 + Main.rand.Next(2);
        }
        private static bool FlyffChance(int drawTimes)
        {
            if(Main.expertMode) return Main.rand.Next(8) + drawTimes <= 2;
            else return Main.rand.Next(5) + drawTimes <= 1;
        }

        #endregion

        // ====== // Override Functions \\ ====== \\
        #region MonsterEffects

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Merchant && CheezePlayer.sellFlare)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Flare);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.BlueFlare);
                nextSlot++;
            }
            if(type == NPCID.ArmsDealer)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("Rocket0"));
                nextSlot++;
            }
            base.SetupShop(type, shop, ref nextSlot);
        }
        public override void ResetEffects(NPC npc)
        {
            this.radiation = false;
            this.extremeRadiation = false;
            this.downfall = false;
            this.angelsBane = false;
            this.sellFlare = false;
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (downfall == true)
            {
                if (npc.boss == false && npc.noTileCollide == false)
                {
                    npc.noGravity = false;
                    npc.velocity.Y += 2;
                    npc.velocity.Y *= 0.85f;
                    drawColor.R /= 2;
                    drawColor.G /= 2;
                }
            }
            if (angelsBane == true)
            {
                if (npc.life > 1000)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("WhiteLightCircle"), npc.velocity.X * 0.3f, npc.velocity.Y * 0.3f);
                        drawColor.B /= 2;
                    }
                }
                if (Main.rand.Next(3) == 0)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("YellowLight"), npc.velocity.X * 0.3f, npc.velocity.Y * 0.3f);
                    drawColor.B /= 2;
                }
            }

            if (radiation)
            {
                //if (Main.rand.Next(3) == 0)
                // {
                //    Dust.NewDust(player.position, player.width, player.height, DustID.AncientLight, player.velocity.X * 0.3f, player.velocity.Y * 0.3f);
                // }
                drawColor.G *= 2;
                drawColor.B /= 2;
                Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("Radiation"), npc.velocity.X * 0.3f, npc.velocity.Y * 0.3f);
            }
            if (extremeRadiation)
            {
                drawColor.R /= 2;
                drawColor.G *= 3;
                drawColor.B /= 2;
                Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("ExtremeRadiation"), npc.velocity.X * 0.3f, npc.velocity.Y * 0.3f);
            }
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (angelsBane == true)
            {
                if (npc.life > 1000)
                {
                    npc.lifeRegen -= 100;
                    damage = 10 + Main.rand.Next(10);
                    npc.lifeRegenExpectedLossPerSecond = 100;
                }
                else
                {
                    npc.lifeRegen -= 50;
                    damage = 5+Main.rand.Next(5);
                    npc.lifeRegenExpectedLossPerSecond = 50;
                }

            }
            if(radiation)
            {
                npc.lifeRegen -= 30;
                if (damage < 3)
                {
                    damage = 3;
                }
                npc.defense -= 5;
                npc.lifeRegenExpectedLossPerSecond = 30;
            }
            if (extremeRadiation)
            {
                npc.lifeRegen -= 120;
                if(damage<12)
                {
                    damage = 12;
                }
                npc.defense -= 10;
                npc.lifeRegenExpectedLossPerSecond = 120;
            }
        }
        #endregion
        #region MonsterLoot
        // == Monster Drops == \\
        public override void NPCLoot(NPC npc)
        {
            // Biomes //
            #region Biomes
            // Granite

            if (npc.type == NPCID.GraniteGolem || npc.type == 483) // 483 is the ID of Granite Elemental.
            { // Granite

                for (int i = 0; i <= 5; i++) // 6 times.
                {
                    if (Main.rand.Next(5) == 0) // 20% chance .
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteShard"), 1);
                    }
                }
            }

            // Marble

            if (npc.type == NPCID.Medusa || npc.type == NPCID.GreekSkeleton)
            {
                for (int i = 0; i <= 5; i++) // 6 times.
                {
                    if (Main.rand.Next(5) == 0) // 25% chance.
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RelicFragment"), 1);
                    }
                }
            }

            //Meteor

            if (npc.type == NPCID.MeteorHead)
            {
                if (Main.rand.Next(5) == 0) // 20% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MeteoriteBolt"), Main.rand.Next(3) + 1);
                }
            }

            //Underworld

            if (npc.type == 39) // Bone Serpent
            {
                if (Main.rand.Next(100) == 0) // 1% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 220, 1);
                }
                if (Main.rand.Next(100) == 0) // 1% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 218, 1);
                }
            }

            if (npc.type == 24) // Fire Imp
            {
                if (Main.rand.Next(400) == 0) // 0.25% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2364, 1);
                }
                if (Main.rand.Next(200) == 0) // 0.5% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 112, 1);
                }
            }

            if (npc.type == NPCID.Hellbat || npc.type == NPCID.Lavabat)
            {
                for (int i = 0; i <= 1; i++) // 2 times.
                {
                    if (Main.rand.Next(2) == 0) // 50% chance.
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FlameWing"), 1);
                    }

                }
            }
            //Dungeon

            if (npc.type == NPCID.AngryBones || npc.type == NPCID.AngryBonesBig || npc.type == NPCID.AngryBonesBigHelmet || npc.type == NPCID.AngryBonesBigMuscle)
            {
                if (Main.rand.Next(140) == 0) // 0.7% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Bonemerang"), 1);
                }
            }

            if (npc.type == NPCID.Paladin)
            {
                if (Main.rand.Next(10) == 0) // 10% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrossNecklace, 1);
                }
            }

            if (npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.FlyingSnake)
            {
                if (Main.rand.Next(66) == 0) // ~1.5% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Kaboomerang"), 1);
                }
            }
            #endregion

            //Invasions //
            #region Invasions

            //Goblin Army

            if (npc.type == 26 || npc.type == 27 || npc.type == 28 || npc.type == 29 || npc.type == 111)
            { // Pre-Hardmode Goblin army monsters
                if (Main.rand.Next(400) == 0) // 0.25% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 128, 1);
                }
            }

            // Pirate Invasion

            if (npc.type == NPCID.PirateShip)
            {
                for (int i = 0; i < Main.rand.Next(20) + 1; i++)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShipWreckage"), 1);
                }
            }

            // Solar Eclipse

            if (npc.type == NPCID.Mothron)
            {
                if (Main.rand.NextFloat() >= 0.7f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornHeroBook"), 1);
                }
                if (Main.rand.NextFloat() >= 0.7f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RavagedHeroBow"), 1);
                }
            }
            if (npc.type == NPCID.ThePossessed || npc.type == NPCID.Eyezor || npc.type == NPCID.Fritz)
            {
                if (Main.rand.NextFloat() >= 0.99)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornHeroBook"), 1);
                }
                if (Main.rand.NextFloat() >= 0.99)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RavagedHeroBow"), 1);
                }
                if (Main.rand.NextFloat() >= 0.99)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrokenHeroSword, 1);
                }
            }
            #endregion

            // Bosses //
            #region Bosses
            if (Main.expertMode == false)
            {
                if (!ModLoader.GetLoadedMods().Contains("QualityOfLifeStandard"))
                {
                    if (npc.type == NPCID.KingSlime)
                    {
                        if (Main.rand.Next(6) == 0)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff, 1);
                        }
                    }
                }
                if (npc.type == NPCID.SkeletronHead)
                {
                    bool ironOrMeteoriteBolt = false;
                    if (Main.rand.Next(2) == 0)
                    {
                        ironOrMeteoriteBolt = true;
                    }
                    int drawChance = 0;
                    for (int i = 0; i < Main.rand.Next(3); i++)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GuardianEssence"), 1);
                    }
                    if (ironOrMeteoriteBolt)Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MeteoriteBolt"), Main.rand.Next(3) + 1);
                    else Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IronBolt"), Main.rand.Next(3) + 1);
                    
                    for (int i = 0; i < FlyffMax(); i++)
                    {
                        if (FlyffChance(drawChance))
                        {
                            int selection = Main.rand.Next(CheezeItem.guardianList.Length);
                            string selectedWeapon = CheezeItem.guardianList[selection];
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(selectedWeapon), 1);
                            drawChance++;
                        }
                    }
                }

                if (npc.type == NPCID.WallofFlesh)
                {
                    int drawChance = 0;
                    for (int i = 0; i < Main.rand.Next(3); i++)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HistoricEssence"), Main.rand.Next(3));
                    }
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HellstoneBolt"), Main.rand.Next(50) + 10);
                    for (int i = 0; i < FlyffMax(); i++)
                    {
                        if (FlyffChance(drawChance))
                        {
                            int selection = Main.rand.Next(CheezeItem.historicList.Length);
                            string selectedWeapon = CheezeItem.historicList[selection];
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(selectedWeapon), 1);
                            drawChance++;
                        }
                    }
                }
                //Hardmode Mech Bosses
                if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism || npc.type == NPCID.TheDestroyer || npc.type == NPCID.SkeletronPrime)
                {
                    if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
                    {
                        for (int i = 0; i < Main.rand.Next(25) + 5; i++)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HallowedBolt"), 1);
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AngelEssence"), 1);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Main.rand.Next(50) + 10; i++)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HallowedBolt"), 1);
                        }
                    }
                }

                if (npc.type == NPCID.MoonLordCore)
                {
                    for (int i = 0; i < Main.rand.Next(50) + 10; i++)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LuminiteBolt"), 1);
                    }
                }
            }
            #endregion

            // Other //
            #region Other


            // Herpaderp

            if (npc.type == NPCID.Herpling || npc.type == NPCID.Derpling)
            {
                if (Main.rand.NextFloat() >= 0.9f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Cheese"), 1);
                }
            }
            #endregion
        }
        // == Boss Bags == \\
        public class BossBags : GlobalItem
        {
            public override void OpenVanillaBag(string context, Player player, int arg)
            {
                if (context == "bossBag" && arg == ItemID.KingSlimeBossBag)
                {
                    if (Main.rand.Next(5) == 0)
                    {
                        player.QuickSpawnItem(ItemID.SlimeStaff);
                    }
                }
                if (context == "bossBag" && arg == ItemID.SkeletronBossBag)
                {
                    bool ironOrMeteoriteBolt = false;
                    if (Main.rand.Next(2) == 0)
                    {
                        ironOrMeteoriteBolt = true;
                    }
                    int drawChance = 0;
                    for (int i = 0; i < 1+Main.rand.Next(4); i++)
                    {
                        player.QuickSpawnItem(mod.ItemType("GuardianEssence"), Main.rand.Next(3));
                    }
                    if (ironOrMeteoriteBolt)player.QuickSpawnItem(mod.ItemType("IronBolt"), Main.rand.Next(50) + 10);
                    else player.QuickSpawnItem(mod.ItemType("MeteoriteBolt"), Main.rand.Next(50) + 10);
                    for (int i = 0; i < FlyffMax(); i++)
                    {
                        if (FlyffChance(drawChance))
                        {
                            int selection = Main.rand.Next(CheezeItem.guardianList.Length);
                            string selectedWeapon = CheezeItem.guardianList[selection];
                            player.QuickSpawnItem(mod.ItemType(selectedWeapon), 1);
                            drawChance++;
                        }
                    }
                }
                if (context == "bossBag" && arg == ItemID.WallOfFleshBossBag)
                {
                    int drawChance = 0;
                    for (int i = 0; i < 1+Main.rand.Next(4); i++)
                    {
                        player.QuickSpawnItem(mod.ItemType("HistoricEssence"), Main.rand.Next(3));
                    }
                    player.QuickSpawnItem(mod.ItemType("HellstoneBolt"), Main.rand.Next(50) + 10);
                    
                    for (int i = 0; i < FlyffMax(); i++)
                    {
                        if (FlyffChance(drawChance))
                        {
                            int selection = Main.rand.Next(CheezeItem.historicList.Length);
                            string selectedWeapon = CheezeItem.historicList[selection];
                            player.QuickSpawnItem(mod.ItemType(selectedWeapon), 1);
                            drawChance++;
                        }
                    }
                }
                if (context == "bossBag" && arg == ItemID.SkeletronPrimeBossBag || arg == ItemID.DestroyerBossBag || arg == ItemID.TwinsBossBag)
                {
                    player.QuickSpawnItem(mod.ItemType("HallowedBolt"), Main.rand.Next(50) + 10);
                    int drawChance = 0;
                    for (int i = 0; i < 1 + Main.rand.Next(4); i++)
                    {
                        player.QuickSpawnItem(mod.ItemType("AngelEssence"), Main.rand.Next(3));
                    }
                    player.QuickSpawnItem(mod.ItemType("HellstoneBolt"), Main.rand.Next(50) + 10);

                    for (int i = 0; i < FlyffMax(); i++)
                    {
                        if (FlyffChance(drawChance))
                        {
                            int selection = Main.rand.Next(CheezeItem.angelList.Length);
                            string selectedWeapon = CheezeItem.angelList[selection];
                            player.QuickSpawnItem(mod.ItemType(selectedWeapon), 1);
                            drawChance++;
                        }
                    }
                }
                if (context == "bossBag" && arg == ItemID.MoonLordBossBag)
                {
                    player.QuickSpawnItem(mod.ItemType("LuminiteBolt"), Main.rand.Next(50) + 10);
                }
            }
        }
        #endregion
    }
}