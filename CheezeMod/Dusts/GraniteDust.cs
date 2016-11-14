using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Dusts
{
	public class GraniteDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
            dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.noLight = false;
			dust.scale *= 1.8f;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.99f;
            if (dust.scale < 0.8f)
			{
				dust.active = false;
			}
			return false;
		}
    }
}