using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.NPCs.Friendly
{
    public class MartianTrader : ModNPC
    {
        public override bool Autoload(ref string name, ref string texture, ref string[] altTextures)
        {
            name = "Martian Trader";
            return mod.Properties.Autoload;
        }
        public override void SetDefaults()
        {
            npc.name = "Martian Trader";
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
            NPCID.Sets.ExtraTextureCount[npc.type] = 0;
            animationType = NPCID.GoblinTinkerer;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            int num = npc.life > 0 ? 1 : 5;
            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if(NPC.downedMartians)
            {
                return true;
            }
            return false;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(7))
            {
                case 0:
                    return "Ray";
                case 1:
                    return "Spock";
                case 2:
                    return "Admiral Aarklash";
                case 3:
                    return "Boros";
                case 4:
                    return "Marvin";
                case 5:
                    return "Watta";
                case 6:
                    return "Neytiri";
                case 7:
                    return "Kagura";
                default:
                    return "E.T.";
            }
        }
        public override string GetChat()
        {
            int goblinTinkerer = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
            if (goblinTinkerer >= 0 && Main.rand.Next(6) == 0)
            {
                return "Another facinating lifeform on this planet is " + Main.npc[goblinTinkerer].displayName + " he would be of the race called a goblin, right?";
            }
            switch (Main.rand.Next(5))
            {
                case 0:
                    return "Terrarian goods are facinating, I want to add them to my collection.";
                case 1:
                    return "I'm sorry of the agressiveness of my brethen, why can't we all just live in peace?";
                case 2:
                    return "I've been starbound for so long, it's good to be on a planet once again!";
                case 3:
                    return "Slimes are odd creatures..., I wonder why they don't get stuck to the ground.";
                default:
                    return "I've been to so many stars and worlds, I have goods from all over the galaxy!";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Lang.inter[28];
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("MegaCorpVendor"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("IronBolt"));
            shop.item[nextSlot].shopCustomPrice = 2500;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("MeteoriteBolt"));
            shop.item[nextSlot].shopCustomPrice = 5000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("HallowedBolt"));
            shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
            if (NPC.downedMoonlord)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("LuminiteBolt"));
                shop.item[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
            }
            shop.item[nextSlot].SetDefaults(ItemID.MartianConduitPlating);
            shop.item[nextSlot].shopCustomPrice = 100;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.MeteoriteBrick);
            shop.item[nextSlot].shopCustomPrice = 150;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Glass);
            shop.item[nextSlot].shopCustomPrice = 70;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.GPS);
            nextSlot++;
            if (Main.dayTime)
            {
                shop.item[nextSlot].SetDefaults(ItemID.CopperBrick);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.CopperPlating);
                shop.item[nextSlot].shopCustomPrice = 125;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SilverBrick);
                shop.item[nextSlot].shopCustomPrice = 150;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.GoldBrick);
                shop.item[nextSlot].shopCustomPrice = 175;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.CobaltBrick);
                shop.item[nextSlot].shopCustomPrice = 200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.MythrilBrick);
                shop.item[nextSlot].shopCustomPrice = 225;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.AdamantiteBeam);
                shop.item[nextSlot].shopCustomPrice = 250;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteBrick);
                shop.item[nextSlot].shopCustomPrice = 300;
                nextSlot++;
            }
            else
            {
                shop.item[nextSlot].SetDefaults(ItemID.TinBrick);
                shop.item[nextSlot].shopCustomPrice = 110;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.TinPlating);
                shop.item[nextSlot].shopCustomPrice = 135;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.TungstenBrick);
                shop.item[nextSlot].shopCustomPrice = 160;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.PlatinumBrick);
                shop.item[nextSlot].shopCustomPrice = 185;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.PalladiumColumn);
                shop.item[nextSlot].shopCustomPrice = 210;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.BubblegumBlock);
                shop.item[nextSlot].shopCustomPrice = 235;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.TitanstoneBlock);
                shop.item[nextSlot].shopCustomPrice = 260;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ShroomitePlating);
                shop.item[nextSlot].shopCustomPrice = 350;
                nextSlot++;
            }
            if(NPC.downedMoonlord)
            {
                shop.item[nextSlot].SetDefaults(ItemID.LunarBrick);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
            }
            // Here is an example of how your npc can sell items from other mods.
            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("ThoriumBlock"));
                shop.item[nextSlot].shopCustomPrice = 200;
                nextSlot++;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 50;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.ElectrosphereMissile;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}