using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using CheezeMod;

namespace CheezeMod
{
    public class CheezeWorld : ModWorld
    {
        public static int secondTimer = 0;
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int CheezeShinies = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

            tasks.Insert(CheezeShinies + 1, new PassLegacy("Cheeze Shinies", delegate (GenerationProgress progress)
            {
                {
                    for (int num5 = 0; num5 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00034); num5++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)WorldGen.worldSurfaceLow), (double)WorldGen.genRand.Next(7, 12), WorldGen.genRand.Next(7, 11), mod.TileType("StarlightOre"), false, 0f, 0f, false, true);
                    }
                }
            }));
        }
        public override void PostUpdate()
        {
            secondTimer++;
            if (secondTimer >= 60) secondTimer = 0;
            base.PostUpdate();
        }
    }
}
