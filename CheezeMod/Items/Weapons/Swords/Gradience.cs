using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
	public class Gradience : ModItem
	{
		private Vector2 speed = new Vector2(0,0);
		private int type = 0;
		private int projectileDamage = 10;
		private float projectileKnockBack = 2f;
		public override void SetDefaults()
		{

			item.damage = 20;
			item.melee = true;
			item.width = 44;
			item.height = 54;


            item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 50000;
            item.scale = 1f;
			item.rare = 3;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gradience");
      Tooltip.SetDefault("Warning, packs a punch!\nGrants three second of endurance on hit.");
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
	        Lighting.AddLight(new Vector2(player.position.X, player.position.Y), 0f, 0.65f, 0.65f);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
	        speed = Vector2.Normalize(target.position - player.position) * 5f;
	        type = mod.ProjectileType("BlueLaserArray");
	        Shoot(player, ref player.position, ref speed.X, ref speed.Y, ref type, ref projectileDamage,
		        ref projectileKnockBack);
            player.AddBuff(114, 200); // 114 is Endurance
        }
	}
}
