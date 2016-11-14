using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Vanilla
{
	public class HappyGrenade : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.PartyGirlGrenade)
			{
                item.maxStack = 999;
                item.ammo = ProjectileID.Grenade;
			}
		}
	}
}