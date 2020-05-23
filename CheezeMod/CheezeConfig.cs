using System;
using System.ComponentModel;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CheezeMod
{
    public class CheezeConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        
        public static CheezeConfig Instance;
        
        [DefaultValue(true)]
        [Tooltip("Enable Recipes for Mod Specific Endless Ammo and Thrown items.")]
        [Slider]
        [Label("Endless Ammo Recipes :")]
        [ReloadRequired]
        public bool EndlessAmmoRecipes = true;

        [Tooltip("Amount of ammo needed to craft an endless variant.")]
        [DefaultValue(3996)] [Label("Ammo required for Endless Ammo :")] [ReloadRequired]
        public int EndlessAmmoAmount = 3996;
        
        

        //The file will be stored in "Terraria/ModLoader/Mod Configs/Example Mod.json"
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "CheezeMod.json");
        
        
    }
}