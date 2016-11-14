using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.NPCs
{
	public class CheezeGlobalNPC : GlobalNPC
	{
        public override void NPCLoot(NPC npc)
        {
            // Biomes //
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
                    if (Main.rand.Next(5) == 0) // 20% chance.
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RelicFragment"), 1);
                    }

                }
            }

            //Meteor

            if(npc.type == NPCID.MeteorHead)
            {
                if (Main.rand.Next(5) == 0) // 20% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MeteoriteBolt"), Main.rand.Next(3)+1);
                }
            }
            
            //Underworld

            if (npc.type == NPCID.Hellbat || npc.type == NPCID.Demon || npc.type == NPCID.LavaSlime || npc.type == NPCID.FireImp || npc.type == NPCID.VoodooDemon || npc.type == NPCID.Lavabat || npc.type == NPCID.RedDevil) // All pre-hardmode Underworld monsters
            {
                if (Main.rand.Next(10) == 0) // 10% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HellstoneBolt"), Main.rand.Next(3));
                }
            }

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
                if (Main.rand.Next(150) == 0) // 0.67% chance.
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Bonemerang"), 1);
                }
            }

            if(npc.type == NPCID.Paladin)
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

            //Invasions//
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
                for(int i = 0; i< Main.rand.Next(20) + 1; i++)
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
                if(Main.rand.NextFloat() >= 0.99)
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

            // Bosses //

            if(npc.type == NPCID.SkeletronHead)
            {
                for (int i = 0; i < Main.rand.Next(10) + 5; i++)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GuardianEssence"), 1);
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

            // Other //

            // Herpaderp

            if (npc.type == NPCID.Herpling || npc.type == NPCID.Derpling)
            {
                if (Main.rand.NextFloat() >= 0.9f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Cheese"), 1);
                }
            }
        }
    }
}