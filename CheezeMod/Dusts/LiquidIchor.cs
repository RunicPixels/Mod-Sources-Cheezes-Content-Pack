using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Dusts
{
	public class LiquidIchor : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
            dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.noLight = false;
			dust.scale *= 0.7f;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.99f;
            float light = 0.35f * dust.scale;
            Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.2f, 0.2f, 0f);
            if (dust.scale < 0.3f)
			{
				dust.active = false;
			}
			return false;
		}
    }
}