using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Buffs
{
	public class MegaAgentOfDread : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Mega Agent of Dread");
            Description.SetDefault("The mega agent of dread will fight for you");
            Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			CheezePlayer modPlayer = player.GetModPlayer<CheezePlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("MegaAgentOfDread")] > 0)
			{
				modPlayer.agentMegaDreadMinion = true;
			}
			if (!modPlayer.agentMegaDreadMinion)
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