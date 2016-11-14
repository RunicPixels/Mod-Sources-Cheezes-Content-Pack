using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Vanilla
{
	public class StickyGrenade : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.StickyGrenade)
			{
                item.maxStack = 999;
                item.ammo = ProjectileID.Grenade;
			}
		}
	}
}