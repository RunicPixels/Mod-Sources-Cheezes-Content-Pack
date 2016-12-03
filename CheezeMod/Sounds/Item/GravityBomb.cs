using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Sounds.Item
{
	public class Gravity : ModSound
	{
		public override void PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		{
			soundInstance = sound.CreateInstance();
			soundInstance.Volume = volume * .4f;
			Main.PlaySoundInstance(soundInstance);
		}
	}
}
