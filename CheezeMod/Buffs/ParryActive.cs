using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Buffs
{
    public class ParryActive : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Parrying Moment");
            Description.SetDefault("Provides a bonus effect to fist weapons with parry");
        }

    }
}