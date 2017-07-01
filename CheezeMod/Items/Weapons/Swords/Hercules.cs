using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
	public class Hercules : ModItem
	{
		public override void SetDefaults()
		{

            item.damage = 25;
			item.melee = true;
			item.width = 58;
			item.height = 62;


            item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 50000;
			item.rare = 3;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Hercules");
      Tooltip.SetDefault("Goes way back.\nGrants three second of rage on hit.");
    }


		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(117, 10); // 117 is a Meteorite Bar
            recipe.AddIngredient(null, "RelicFragment", 15);
            recipe.AddIngredient(ItemID.FossilOre, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("ShortSparkle"));
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
            player.AddBuff(115, 200);
        }
	}
}
