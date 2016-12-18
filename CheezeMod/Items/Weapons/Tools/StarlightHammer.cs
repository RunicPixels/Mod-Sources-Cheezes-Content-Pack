using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Tools
{
	public class StarlightHammer : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Starlight Hammer";
			item.damage = 18;
			item.melee = true;
			item.width = 32;
			item.height = 34;
			item.toolTip = "A star in its class.";
			item.useTime = 26;
            item.scale = 1.2f;
			item.useAnimation = 26;
			item.hammer = 64;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 10000;
			item.rare = 2;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "StarlightBar", 12);
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