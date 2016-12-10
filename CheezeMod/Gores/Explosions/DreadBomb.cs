using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Gores.Explosions
{
    public class DreadBomb : ModGore
    {
        Vector2 baseGorePosition;
        int goreFrame;
        public override void OnSpawn(Gore gore)
        {
            gore.numFrames = 4;
            gore.frame = 0;
            gore.sticky = true;
            gore.timeLeft = 12;
            gore.scale = 1f;
            baseGorePosition = gore.position;
            goreFrame = 0;
        }
        public override bool Update(Gore gore)
        {
            gore.velocity.X = 0f;
            gore.velocity.Y = 0f;
            gore.scale += 0.07f;
            gore.position = baseGorePosition;
            if (goreFrame >= 12)
            {
                gore.frame = 3;
                gore.frameCounter = 3;
                gore.alpha += 15;
            }
            else if (goreFrame >= 6)
            {
                gore.frame = 2;
                gore.frameCounter = 2;
                gore.alpha +=25;
            }
            else if (goreFrame >= 3)
            {
                gore.frame = 1;
                gore.frameCounter = 1;
            }
            else
            {
                gore.frame = 0;
                gore.frameCounter = 0;
            }
            if (goreFrame >= 13)
            {
                gore.active = false;
                gore.light -= 0.1f;
                return false;
            }
            goreFrame++;
            return true;
        }
    }
}