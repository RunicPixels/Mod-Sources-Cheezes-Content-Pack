using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
	public class Gradience : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Gradience";
			item.damage = 30;
			item.melee = true;
			item.width = 60;
			item.height = 72;
			item.toolTip = "Warning, packs a punch!";
            item.toolTip2 = "Grants three second of endurance on hit.";
            item.useTime = 42;
			item.useAnimation = 42;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 50000;
            item.scale = 0.9f;
			item.rare = 3;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(46);
            recipe.AddIngredient(null, "GraniteShard", 20);
            recipe.AddIngredient(173, 10);
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(795);
            recipe.AddIngredient(null, "GraniteShard", 20);
            recipe.AddIngredient(173, 10);
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("DarkSparkle"));
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
            player.AddBuff(114, 200); // 114 is Endurance
        }
	}
}