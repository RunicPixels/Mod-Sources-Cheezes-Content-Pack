using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
	public class NietonoNoShana : ModItem
	{
		public override void SetDefaults()
		{

            item.damage = 70;
			item.melee = true;
			item.width = 58;
			item.height = 64;


            item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 50000;
			item.rare = 6;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nietono No Shana");
      Tooltip.SetDefault("To be wielded by the flame haze.\nBurns your enemies.");
    }


		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 9);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(null, "FlameWing", 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
              
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(BuffID.OnFire, 300);
        }
	}
}
