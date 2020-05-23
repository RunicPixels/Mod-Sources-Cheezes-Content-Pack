using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Buffs
{
	public class AgentOfDoom : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Agent of Doom");
            Description.SetDefault("The agent of doom will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
		{
			CheezePlayer modPlayer = player.GetModPlayer<CheezePlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AgentOfDoom")] > 0)
			{
				modPlayer.agentMinion = true;
			}
			if (!modPlayer.agentMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}