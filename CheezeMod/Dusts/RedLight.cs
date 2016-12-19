using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Dusts
{
	public class RedLight : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
            dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.noLight = false;
			dust.scale *= 1.5f;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.20f;
			dust.scale *= 0.98f;
            float light = 0.25f * dust.scale;
            Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.7f, 0.2f, 0.2f);
            if (dust.scale < 0.4f)
			{
				dust.active = false;
			}
			return false;
		}
    }
}