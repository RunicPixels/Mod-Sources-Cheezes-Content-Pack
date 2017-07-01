using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Buffs
{
	public class Starlit : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Starlit");
            Description.SetDefault("Your magical attacks and mana regen are empowered by the stars.");
			Main.buffNoSave[Type] = false;
			Main.debuff[Type] = false;
			canBeCleared = true;
		}
        public override void Update(Player player, ref int buffIndex)
        {
            player.manaRegenBonus += 20;
            player.magicDamage *= 1.25f;
        }
    }
}
