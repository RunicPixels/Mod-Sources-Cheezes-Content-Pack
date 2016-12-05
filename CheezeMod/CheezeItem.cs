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

        #region FlyffStatsInfo
        public static String[] guardianList =
        {
            "GuardianSword","GuardianAxe","GuardianBigSword","GuardianAmbidextrousAxe","GuardianPickaxe","GuardianStick","GuardianKnuckle","GuardianBow","GuardianYoyo","GuardianWand","GuardianStaff"
        };
        public static String[] historicList =
        {
            "HistoricSword","HistoricAxe","HistoricBigSword","HistoricAmbidextrousAxe","HistoricPickaxe","HistoricStick","HistoricKnuckle","HistoricBow","HistoricYoyo","HistoricWand","HistoricStaff"
        };

        public static int guardianPrice = 25000;
        public static int historicPrice = guardianPrice * 3;


        public static int guardianRarity = 2;
        public static int historicRarity = 4;
        #endregion
        #region RatchetStatsInfo 
        public static String[] ratchetTier1List =
        {
            "BombGlove","Walloper","Lancer","GravityBomb","Chopper","LavaGun","Bouncer","BlitzGun","PulseRifle"
        };
        public static String[] ratchetTier2List =
        {
            "GoldBombGlove","GoldWalloper","HeavyLancer","Multistar","LiquidNitrogenGun","HeavyBouncer","BlitzCannon","Vaporizer"
        };
        #endregion
    }
}
