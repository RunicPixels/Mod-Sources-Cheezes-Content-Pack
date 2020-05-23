using Terraria;
using Terraria.ModLoader;
using CheezeMod;
using CheezeMod.NPCs;

namespace CheezeMod.Buffs
{
	public class Radiation : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Radiation");
            Description.SetDefault("Irradiated, Lower Armor and Losing Health");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<CheezePlayer>().radiation = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<CheezeGlobalNPC>().radiation = true;
		}
	}
}
