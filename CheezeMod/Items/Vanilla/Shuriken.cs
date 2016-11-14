using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Vanilla
{
	public class Shuriken : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.Shuriken)
			{
                item.ammo = ProjectileID.Shuriken;
			}
		}
	}
}