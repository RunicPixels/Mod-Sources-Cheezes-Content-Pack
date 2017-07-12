using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod.Items;
using CheezeMod.NPCs;
using CheezeMod.UI;
using System.Drawing;
using System.Linq;
using System.IO;
using Terraria.Localization;
using System.Collections.Generic;
using Terraria.UI;

namespace CheezeMod
{
    public class CheezeMod : Mod
    {
        public CheezeMod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
        // UI
        #region UI
        public UserInterface customResources;
        public AmmoUI ammoUI;

        public override void Load()
        {
            if (Main.dedServ)
            {
                customResources = new UserInterface();
                ammoUI = new AmmoUI();
                AmmoUI.visible = true;
                customResources.SetState(ammoUI);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int vanillaResourceBar = layers.FindIndex(layer => layer.Name.Equals("Resource Bars"));
            if (vanillaResourceBar != -1)
            {
                    //Add you own layer
                    layers.Insert(vanillaResourceBar, new LegacyGameInterfaceLayer("CustomBars: Custom Resource Bar", delegate
                    {
                        if (AmmoUI.visible)
                        {
                            customResources.Update(Main._drawInterfaceGameTime);
                            ammoUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    }, InterfaceScaleType.UI)
                    );
            }
            if (AmmoUI.visible)
            {
                //Update CustomBars
                customResources.Update(Main._drawInterfaceGameTime);
                ammoUI.Draw(Main.spriteBatch);
            }

        }
        #endregion
        // MATH and DRAWING //
        #region MathInfo
        public static int BooleanToInt(bool parameter)
        {
            if (parameter == true) return 1;
            else return 0;
        }

        public static float CalculateSpread(float spreadInput, float speedX, float speedY, char XorY)
        {
            float spread = spreadInput * 0.0174f; // degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
            float randomSpeed = Main.rand.NextFloat() * 0.05f + 0.975f;
            speedX = baseSpeed * randomSpeed * (float)Math.Sin(randomAngle);
            speedY = baseSpeed * randomSpeed * (float)Math.Cos(randomAngle);
            if (XorY == 'X')
            {
                return speedX;
            }
            else
            {
                return speedY;
            }
        }

        #endregion
        // NETWORK //
        #region NetUpdate

        //These Network Methods are property of FlashKirby, do not copy them without his permission.
        public static void NetUpdateParry(Mod mod, PlayerFX pfx)
        {
            if (Main.netMode == 1 && pfx.player.whoAmI == Main.myPlayer)
            {
                ModPacket message = mod.GetPacket();
                message.Write(2);
                message.Write(Main.myPlayer);
                message.Write(pfx.parryTimeMax);
                message.Write(pfx.parryActive);
                message.Send();
            }
        }

        public static void NetUpdateDash(Mod mod, PlayerFX pfx)
        {
            if (Main.netMode == 1 && pfx.player.whoAmI == Main.myPlayer)
            {
                ModPacket message = mod.GetPacket();
                message.Write(1);
                message.Write(Main.myPlayer);
                message.Write(pfx.weaponDash);
                message.Send();
            }
        }
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            int code = reader.ReadInt32();
            int sender = reader.ReadInt32();
            if (code == 1) // Set dash used
            {
                int dash = reader.ReadInt32();
                if (Main.netMode == 2)
                {
                    for (int i = 0; i < 255; i++)
                    {
                        if (!Main.player[i].active) continue;
                        if (i != sender)
                        {
                            ModPacket me = GetPacket();
                            me.Write(code);
                            me.Write(sender);
                            me.Write(dash);
                            me.Send();
                        }
                    }
                    // Console.WriteLine("Set player " + Main.player[sender].name + " weapon dash to " + dash);
                }
                else
                {
                    Main.player[sender].GetModPlayer<PlayerFX>(this).weaponDash = dash;
                    // Main.NewText("Set player " + Main.player[sender].name + " weapon dash to " + dash);
                }
            }
        }


        #endregion
        // SPAWNING //
        #region SpawnInfo
        //spawning helper methods imported from bluemagic123's Example Mod.
        public static bool NoInvasion(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.invasion && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime);
        }

        public static bool NoBiome(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            return !player.ZoneJungle && !player.ZoneDungeon && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneSnow && !player.ZoneUndergroundDesert;
        }

        public static bool NoZoneAllowWater(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.sky && !spawnInfo.player.ZoneMeteor && !spawnInfo.spiderCave;
        }

        public static bool NoZone(NPCSpawnInfo spawnInfo)
        {
            return NoZoneAllowWater(spawnInfo) && !spawnInfo.water;
        }

        public static bool NormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.playerInTown && NoInvasion(spawnInfo);
        }

        public static bool NoZoneNormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoZone(spawnInfo);
        }

        public static bool NoZoneNormalSpawnAllowWater(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoZoneAllowWater(spawnInfo);
        }

        public static bool NoBiomeNormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoBiome(spawnInfo) && NoZone(spawnInfo);
        }

        //Spawning Zones for NPC imported from Main Terraria Method//
        public static double HellLayer = (float)((Main.maxTilesY - 204));
        public static double CavernLayer = Main.rockLayer + ((double)(540));
        #endregion
        // CRAFTING //
        #region CraftingInfo
        // Methods related to Stacked Blocks
        public static int stackedBlockNumber = 111;
        public static int blockBaseValue = 18;

        // New Recipe Groups //
        public override void AddRecipeGroups()
        {
            // All Wood //
            RecipeGroup AnyWood = new RecipeGroup(() => Language.GetText("any") + " " + "Any Wood", new int[]
            {
                    ItemID.Wood,
                    ItemID.RichMahogany,
                    ItemID.DynastyWood,
                    ItemID.BorealWood,
                    ItemID.Shadewood,
                    ItemID.Ebonwood,
                    ItemID.SpookyWood,
                    ItemID.PalmWood,
                    ItemID.Pearlwood

            });
            RecipeGroup.RegisterGroup("CheezeMod:AnyWood", AnyWood);

            //Alternative Ores//

            //Copper/Tin Bar//
            RecipeGroup CopperBars = new RecipeGroup(() => Language.GetText("any") + " " + "Copper/Tin Bar", new int[]
            {
                    ItemID.CopperBar,
                    ItemID.TinBar
            });
            RecipeGroup.RegisterGroup("CheezeMod:CopperBars", CopperBars);

            //Iron/Lead Bar//
            RecipeGroup IronBars = new RecipeGroup(() => Language.GetText("any") + " " + "Iron/Lead Bar", new int[]
            {
                    ItemID.IronBar,
                    ItemID.LeadBar
            });
            RecipeGroup.RegisterGroup("CheezeMod:IronBars", IronBars);

            //Silver/Tungsten Bar//
            RecipeGroup SilverBars = new RecipeGroup(() => Language.GetText("any") + " " + "Silver/Tungsten Bar", new int[]
            {
                    ItemID.SilverBar,
                    ItemID.TungstenBar
            });
            RecipeGroup.RegisterGroup("CheezeMod:SilverBars", SilverBars);

            //Gold/Platinum Bar//
            RecipeGroup GoldBars = new RecipeGroup(() => Language.GetText("any") + " " + "Gold/Platinum Bar", new int[]
            {
                    ItemID.GoldBar,
                    ItemID.PlatinumBar
            });
            RecipeGroup.RegisterGroup("CheezeMod:GoldBars", GoldBars);

            //Demonite/Crimtane Bar//
            RecipeGroup EvilBars = new RecipeGroup(() => Language.GetText("any") + " " + "Demonite/Crimtane Bar", new int[]
            {
                    ItemID.DemoniteBar,
                    ItemID.CrimtaneBar
            });
            RecipeGroup.RegisterGroup("CheezeMod:EvilBars", EvilBars);

            //Cobalt/Mythril Bar//
            RecipeGroup CobaltBars = new RecipeGroup(() => Language.GetText("any") + " " + "Cobalt/Palladium Bar", new int[]
            {
                    ItemID.CobaltBar,
                    ItemID.PalladiumBar
            });
            RecipeGroup.RegisterGroup("CheezeMod:CobaltBars", CobaltBars);

            //Mythril/Orichalcum Bar//
            RecipeGroup MythrilBars = new RecipeGroup(() => Language.GetText("any") + " " + "Mythril/Orichalcum Bar", new int[]
            {
                    ItemID.MythrilBar,
                    ItemID.OrichalcumBar
            });
            RecipeGroup.RegisterGroup("CheezeMod:MythrilBars", MythrilBars);

            //Adamantite/Titanium Bar//
            RecipeGroup AdamantiteBars = new RecipeGroup(() => Language.GetText("any") + " " + "Adamantite/Titanium Bar", new int[]
            {
                    ItemID.AdamantiteBar,
                    ItemID.TitaniumBar
            });
            RecipeGroup.RegisterGroup("CheezeMod:AdamantiteBars", AdamantiteBars);

            //Alternative Materials//

            //Cursed Flames/Ichor//
            RecipeGroup CursedFlames = new RecipeGroup(() => Language.GetText("any") + " " + "Cursed Flames/Ichor", new int[]
            {
                    ItemID.CursedFlame,
                    ItemID.Ichor
            });
            RecipeGroup.RegisterGroup("CheezeMod:CursedFlames", CursedFlames);

            //Rotten Chunk/Vertebrae//
            RecipeGroup EvilLeather = new RecipeGroup(() => Language.GetText("any") + " " + "Rotten Chunk/Vertebrae", new int[]
            {
                    ItemID.RottenChunk,
                    ItemID.Vertebrae
            });
            RecipeGroup.RegisterGroup("CheezeMod:EvilLeather", EvilLeather);

            //Ebonkoi/Hemopiranha//
            RecipeGroup EvilFish = new RecipeGroup(() => Language.GetText("any") + " " + "Ebonkoi/Hemopiranha", new int[]
            {
                    ItemID.Ebonkoi,
                    ItemID.Hemopiranha
            });
            RecipeGroup.RegisterGroup("CheezeMod:EvilFish", EvilFish);


            //Alternative Weapons//

            //Silver Bow / Tungsten Bow//
            RecipeGroup SilverBows = new RecipeGroup(() => Language.GetText("any") + " " + "Silver Bow / Tungsten Bow", new int[]
            {
                    ItemID.SilverBow,
                    ItemID.TungstenBow
            });
            RecipeGroup.RegisterGroup("CheezeMod:SilverBows", SilverBows);

            RecipeGroup EvilBows = new RecipeGroup(() => Language.GetText("any") + " " + "Demon Bow / Tendon Bow", new int[]
            {
                    ItemID.DemonBow,
                    ItemID.TendonBow

            });
            RecipeGroup.RegisterGroup("CheezeMod:EvilBows", EvilBows);

            //Light's Bane/Blood Butcherer//
            RecipeGroup EvilSwords = new RecipeGroup(() => Language.GetText("any") + " " + "Light's Bane/Blood Butcherer", new int[]
            {
                    ItemID.LightsBane,
                    ItemID.BloodButcherer
            });
            RecipeGroup.RegisterGroup("CheezeMod:EvilSwords", EvilSwords);

            //NM Pick, Bloody pick//
            RecipeGroup EvilPickaxes = new RecipeGroup(() => Language.GetText("any") + " " + "Nightmare Pickaxe/Deathbringer Pickaxe", new int[]
            {
                    ItemID.NightmarePickaxe,
                    ItemID.DeathbringerPickaxe
            });
            RecipeGroup.RegisterGroup("CheezeMod:EvilPickaxes", EvilPickaxes);
            //Waraxe/BloodLust//
            RecipeGroup EvilAxes = new RecipeGroup(() => Language.GetText("any") + " " + "War Axe of the Night/Blood Lust Cluster", new int[]
            {
                    ItemID.WarAxeoftheNight,
                    ItemID.BloodLustCluster
            });
            RecipeGroup.RegisterGroup("CheezeMod:EvilAxes", EvilAxes);
            //Mythril/Orichalcum Sword//
            RecipeGroup MythSwords = new RecipeGroup(() => Language.GetText("any") + " " + "Mythril/Orichalcum Sword", new int[]
            {
                    ItemID.MythrilSword,
                    ItemID.OrichalcumSword
            });
            RecipeGroup.RegisterGroup("CheezeMod:MythSwords", MythSwords);
        }

        // New Recipes //
        public override void AddRecipes()
        {
            // Jungle Related Recipes //

            // Recipe for Seeds.
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Acorn);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Seed, 50);
            recipe.AddRecipe();

            // Recipes for the Seedler.
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BladeofGrass);
            recipe.AddRecipeGroup("CheezeMod:MythSwords");
            recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.AddIngredient(ItemID.Acorn, 30);
            recipe.AddIngredient(ItemID.JungleGrassSeeds, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.Seedler);
            recipe.AddRecipe();

            // Corruption / Crimson Related recipes //

            // Corruption

            // Baby Eater
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ShadowScale, 5);
            recipe.AddIngredient(ItemID.RottenChunk, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.EatersBone);
            recipe.AddRecipe();

            // Blindfold
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ShadowScale, 5);
            recipe.AddIngredient(ItemID.RottenChunk, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.DarkShard);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.Blindfold);
            recipe.AddRecipe();

            // Crimson

            // Baby Face Monster
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TissueSample, 5);
            recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BoneRattle);
            recipe.AddRecipe();

            // Snow Biome

            // Frozen Turtle Shell
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IceBlock, 50);
            recipe.AddIngredient(ItemID.SnowBlock, 50);
            recipe.AddIngredient(ItemID.TurtleShell, 2);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.FrozenTurtleShell);
            recipe.AddRecipe();

            // Underworld/Fire Relatated recipes //

            // Recipe for the Hellwing Bow
            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "RelicFragment", 3);
            recipe.AddIngredient(null, "FlameWing", 20);
            recipe.AddIngredient(ItemID.MoltenFury);
            recipe.AddTile(77);
            recipe.SetResult(ItemID.HellwingBow);
            recipe.AddRecipe();

            // Recipe for flares
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MusketBall, 9);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(931, 9);
            recipe.AddRecipe();


            // Sky/Stars/Mana/Starlight related recipes //

            // Recipe for Lucky Horseshoe.
            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StarlightBar", 12);
            recipe.AddRecipeGroup("CheezeMod:IronBars", 4);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.LuckyHorseshoe);
            recipe.AddRecipe();

            // Recipe for Starfury
            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StarlightBar", 12);
            recipe.AddIngredient(ItemID.Trident);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.Starfury);
            recipe.AddRecipe();

            // Recipe for Shiny Red Balloon
            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StarlightBar", 12);
            recipe.AddIngredient(ItemID.WhiteString);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.ShinyRedBalloon);
            recipe.AddRecipe();

            // Recipe for Cloud in a bottle.
            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StarlightBar", 9);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Cloud, 25);
            recipe.AddIngredient(ItemID.RainCloud, 5);
            recipe.AddIngredient(ItemID.Feather, 5);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.CloudinaBottle);
            recipe.AddRecipe();

            // Recipe for Sandstorm in a bottle.
            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StarlightBar", 9);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Cloud, 10);
            recipe.AddIngredient(ItemID.SandBlock, 25);
            recipe.AddIngredient(ItemID.DesertFossil, 5);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.SandstorminaBottle);
            recipe.AddRecipe();

            // Recipe for Blizzard in a bottle.
            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StarlightBar", 9);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Cloud, 10);
            recipe.AddIngredient(ItemID.IceBlock, 25);
            recipe.AddIngredient(ItemID.SnowBlock, 25);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.BlizzardinaBottle);
            recipe.AddRecipe();

            // Recipe for Tsunami in a bottle.
            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StarlightBar", 9);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Coral, 10);
            recipe.AddIngredient(ItemID.IceBlock, 25);
            recipe.AddIngredient(ItemID.SnowBlock, 25);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.TsunamiInABottle);
            recipe.AddRecipe();

            // Recipe for Sky Mill
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SunplateBlock, 25);
            recipe.AddIngredient(ItemID.RainCloud, 25);
            recipe.AddIngredient(ItemID.Cloud, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.SkyMill);
            recipe.AddRecipe();

            // Recipe for Sunplate Block
            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StarlightOre");
            recipe.AddIngredient(ItemID.StoneBlock, 3);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.SunplateBlock, 3);
            recipe.AddRecipe();


            // Stacked Blocks Related Recipes //

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedDirtBlock");
            recipe.SetResult(ItemID.DirtBlock, stackedBlockNumber);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedStoneBlock");
            recipe.SetResult(ItemID.StoneBlock, stackedBlockNumber);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedMudBlock");
            recipe.SetResult(ItemID.MudBlock, stackedBlockNumber);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedWood");
            recipe.SetResult(ItemID.Wood, stackedBlockNumber);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedGel");
            recipe.SetResult(ItemID.Gel, stackedBlockNumber);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedSandBlock");
            recipe.SetResult(ItemID.SandBlock, stackedBlockNumber);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedSnowBlock");
            recipe.SetResult(ItemID.SnowBlock, stackedBlockNumber);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedIceBlock");
            recipe.SetResult(ItemID.IceBlock, stackedBlockNumber);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedPearlstoneBlock");
            recipe.SetResult(ItemID.PearlstoneBlock, stackedBlockNumber);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedEbonstoneBlock");
            recipe.SetResult(ItemID.EbonstoneBlock, stackedBlockNumber);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedCrimstoneBlock");
            recipe.SetResult(ItemID.CrimstoneBlock, stackedBlockNumber);
            recipe.AddRecipe();

            // Bulk Crafting Stacked Block
            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "StackedGel");
            recipe.AddIngredient(null, "StackedWood");
            recipe.SetResult(ItemID.Torch, stackedBlockNumber * 3);
            recipe.AddRecipe();

            // Event Related Recipes //

            // Halloween //

            // Goody Bag
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Pumpkin, 3);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GoodieBag);
            recipe.AddRecipe();

            // Black Cat
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SpookyWood, 20);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddIngredient(ItemID.WizardHat);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.UnluckyYarn);
            recipe.AddRecipe();

            // Christmas //

            // Present
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SnowBlock, 30);
            recipe.AddIngredient(ItemID.SoulofLight, 2);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Present);
            recipe.AddRecipe();

            // Puppy
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddRecipeGroup("CheezeMod:CopperBars", 5);
            recipe.AddIngredient(null, "ShipWreckage");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.DogWhistle);
            recipe.AddRecipe();

            // Vanity Related Recipes //

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SnowBlock, 30);
            recipe.AddIngredient(ItemID.BrownDye);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.BallaHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SnowBlock, 30);
            recipe.AddIngredient(ItemID.BlackDye);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.GangstaHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Aglet);
            recipe.AddIngredient(ItemID.Cloud, 25);
            recipe.AddIngredient(ItemID.SpectreBoots);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.LightningBoots);
            recipe.AddRecipe();

            // Other Mods Used //

            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.PiggyBank);
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("UnholyShards"), 100);
                recipe.AddIngredient(null, "FlameWing", 10);
                recipe.AddTile(TileID.TinkerersWorkbench);
                recipe.SetResult(ItemID.MoneyTrough);
                recipe.AddRecipe();

            }
        }
        #endregion
    }
}