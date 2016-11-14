using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Buffs
{
	public class CheeseFed : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[this.Type] = "Cheese!";
			Main.buffTip[this.Type] = "Your feel overwhelmed by cheese, increases defense, life regen and melee stats.";
			Main.buffNoSave[Type] = false;
			Main.debuff[Type] = false;
			canBeCleared = true;
		}
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 3;
            player.statDefense += 2;
            player.meleeCrit += 5;
            player.meleeDamage *= 1.05f;
            player.meleeSpeed *= 1.05f;
            if (Main.rand.Next(5) == 0)
            {
                Dust.NewDust(player.position + player.velocity, player.width, player.height, 32, player.velocity.X * 0.1f, player.velocity.Y * 0.1f);
            }
        }
    }
}
