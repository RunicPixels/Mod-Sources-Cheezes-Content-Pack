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
            DisplayName.SetDefault("Angels Bane");
            Description.SetDefault("Cursed by the Angels of Madrigal, losing hp, deals double damage when above 400hp");
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
			npc.GetGlobalNPC<CheezeGlobalNPC>(mod).angelsBane = true;
		}
	}
}
