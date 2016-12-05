using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Gores.Explosions
{
	public class GravityBomb : ModGore
	{
        Vector2 baseGorePosition;
		public override void OnSpawn(Gore gore)
		{
			gore.numFrames = 3;
			gore.frame = 1;
            gore.sticky = true;
            gore.light = 1f;
            gore.timeLeft = 0;
            gore.scale = 1f;
            baseGorePosition = gore.position;
        }
        public override bool Update(Gore gore)
        {
            gore.velocity.X = 0f;
            gore.velocity.Y = 0f;
            gore.scale += 0.07f;
            gore.position = baseGorePosition;
            if (gore.timeLeft - Gore.goreTime <= -6)
            {
                gore.frame = 2;
                gore.frameCounter = 2;
                gore.alpha = 127;
            }
            else if (gore.timeLeft - Gore.goreTime <= -3)
            {
                gore.frame = 1;
                gore.frameCounter = 1;
            }
            else
            {
                gore.frame = 0;
                gore.frameCounter = 0;
            }
            if(gore.timeLeft - Gore.goreTime <= -12)
            {
                gore.active = false;
                gore.light -= 0.1f;
                return false;
            }
            return true;
        }
    }
}