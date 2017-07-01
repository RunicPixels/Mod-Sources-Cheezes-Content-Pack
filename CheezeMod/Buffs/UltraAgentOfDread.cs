using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Buffs
{
	public class UltraAgentOfDread : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Ultra Agent of Dread");
            Description.SetDefault("The ultra agent of dread will fight for you");
            Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			CheezePlayer modPlayer = player.GetModPlayer<CheezePlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("UltraAgentOfDread")] > 0)
			{
				modPlayer.agentUltraDreadMinion = true;
			}
			if (!modPlayer.agentUltraDreadMinion)
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