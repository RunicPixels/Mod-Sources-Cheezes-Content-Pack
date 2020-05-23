using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Buffs
{
	public class AgentOfDread : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Agent of Dread");
            Description.SetDefault("The agent of dread will fight for you");
            Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			CheezePlayer modPlayer = player.GetModPlayer<CheezePlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AgentOfDread")] > 0)
			{
				modPlayer.agentDreadMinion = true;
			}
			if (!modPlayer.agentDreadMinion)
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