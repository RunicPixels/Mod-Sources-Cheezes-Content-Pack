using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Consumables
{
	public class Cheese : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cheese";
			item.width = 18;
			item.height = 18;
			item.maxStack = 999;
			AddTooltip("Gives well fed for 20 minutes.");
			item.value = 24000;
			item.rare = 8;
            item.useStyle = 2;
            item.useSound = 2;
            item.consumable = true;
		}
        public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.WellFed, 72000);
            player.AddBuff(mod.BuffType("CheeseFed"), 300);
            if (Main.rand.Next(100) == 0)
            {
                item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Moo");
            }
            else
            {
                item.useSound = 2;
            }
            return true;
        }
    }
}