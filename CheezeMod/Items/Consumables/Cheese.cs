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

			item.width = 18;
			item.height = 18;
			item.maxStack = 999;

			item.value = 24000;
			item.rare = 8;
            item.useStyle = 2;
            item.UseSound = SoundID.Item2;
            item.consumable = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cheese");
      Tooltip.SetDefault("Gives well fed for 20 minutes.");
    }

        public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.WellFed, 72000);
            player.AddBuff(mod.BuffType("CheeseFed"), 300);
            if (Main.rand.Next(100) == 0)
            {
                item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, ("Sounds/Item/Moo"));
            }
            else
            {
                item.UseSound = SoundID.Item2;
            }
            return true;
        }
    }
}
