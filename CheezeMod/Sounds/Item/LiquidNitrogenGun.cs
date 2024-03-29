using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Sounds.Item
{
	public class LiquidNitrogenGun : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		{
			soundInstance = sound.CreateInstance();
            soundInstance.Volume = volume * 0.4f;
            return soundInstance;
        }
	}
}
