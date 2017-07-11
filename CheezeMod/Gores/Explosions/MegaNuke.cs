using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Gores.Explosions
{
    public class MegaNuke : ModGore
    {
        Vector2 baseGorePosition;
        int goreFrame;
        public override void OnSpawn(Gore gore)
        {
            gore.numFrames = 7;
            gore.rotation = 0f;
            gore.frame = 0;
            gore.sticky = true;
            gore.timeLeft = 60;
            gore.scale = 1.5f;
            gore.rotation *= 0f;
            baseGorePosition = gore.position;
            goreFrame = 0;
        }
        public override bool Update(Gore gore)
        {
            gore.velocity.X = 0f;
            gore.velocity.Y = 0f;
            gore.rotation *= 0f;
            gore.position = baseGorePosition;
            if (goreFrame >= 35)
            {
                gore.frame = 6;
                gore.frameCounter = 6;
                gore.alpha += 15;
            }
            else if (goreFrame >= 23)
            {
                gore.frame = 5;
                gore.frameCounter = 5;
                gore.alpha += 5;
            }
            else if (goreFrame >= 18)
            {
                gore.frame = 4;
                gore.frameCounter = 4;
                gore.alpha += 1;
            }
            else if (goreFrame >= 13)
            {
                gore.frame = 3;
                gore.frameCounter = 3;
            }
            else if (goreFrame >= 7)
            {
                gore.frame = 2;
                gore.frameCounter = 2;
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
            if (goreFrame >= 50)
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