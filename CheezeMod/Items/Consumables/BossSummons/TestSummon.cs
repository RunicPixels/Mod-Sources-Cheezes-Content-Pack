using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Consumables.BossSummons
{
	public class TestSummon : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "TestSummon";
			item.width = 18;
			item.height = 18;
			item.maxStack = 999;
			AddTooltip("Work in progress, use at own risk.");
			item.value = 2400;
			item.rare = 8;
            item.useStyle = 2;
            item.UseSound = SoundID.Item2;
            item.consumable = true;
		}
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("Susano")) && !Main.dayTime;
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Susano"));
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}