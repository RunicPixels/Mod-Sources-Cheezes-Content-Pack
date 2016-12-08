using Terraria;
using Terraria.ModLoader;
using CheezeMod;
using CheezeMod.NPCs;

namespace CheezeMod.Buffs
{
	public class AngelsBane : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Angels Bane";
			Main.buffTip[Type] = "Cursed by the Angels of Madrigal, losing 5 hp every second, deals twice as much damage when above the surface layer.";
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<CheezePlayer>(mod).angelsBane = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetModInfo<CheezeNPCInfo>(mod).angelsBane = true;
		}
	}
}
