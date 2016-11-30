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
                if (item.maxStack < 999) item.maxStack = 999;
                item.ammo = ProjectileID.Grenade;
			}
		}
	}
}