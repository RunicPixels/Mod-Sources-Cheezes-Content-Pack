using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Tools
{
	public class StarlightPaxel : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.melee = true;
			item.width = 32;
			item.height = 34;

			item.useTime = 19;
            item.scale = 1.2f;
			item.useAnimation = 19;
			item.pick = 64;
            item.axe = 13;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Starlight Paxel");
      Tooltip.SetDefault("Functions as a Pickaxe as well as an axe. Mines up to Demonite.");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "StarlightBar", 15);
			recipe.AddTile(TileID.SkyMill);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(12) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("ShortSparkle"));
			}
		}
	}
}
