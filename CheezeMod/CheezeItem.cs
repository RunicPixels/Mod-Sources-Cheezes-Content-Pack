using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CheezeMod;


// CS file for general item values and declarations.
namespace CheezeMod
{
    public class CheezeItem
    {
        public static int defaultHalberdHeight = 48;
        public static int defaultHalberdWidth = 46;


        public static String[] guardianList =
        {
            "GuardianSword","GuardianAxe","GuardianBigSword","GuardianAmbidextrousAxe","GuardianPickaxe","GuardianStick","GuardianKnuckle","GuardianBow","GuardianYoyo","GuardianWand","GuardianStaff"
        };
        public static int guardianPrice = 25000;
        public static String[] historicList =
        {
            "HistoricSword","HistoricAxe","HistoricBigSword","HistoricAmbidextrousAxe","HistoricPickaxe","HistoricStick","HistoricKnuckle","HistoricBow","HistoricYoyo","HistoricWand","HistoricStaff"
        };
        public static int historicPrice = 75000;
    }
}
