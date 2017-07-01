using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
	public class SunStrike : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.StarWrath);



            item.useTime = 48;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.alpha = 0;
            item.rare = 4;
            item.reuseDelay = 32;
            item.useAnimation = 32;
            item.damage = 37;
            item.knockBack = 7;
            item.value = 225000;
            item.autoReuse = true;
            item.scale = 1f;
            item.shoot = 10;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sun Strike");
      Tooltip.SetDefault("Shoots out Sunstrikes to ingite your enemies.\nAlso provides one second of either 'rage' or 'endurance' on direct hit.");
    }



        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
            Lighting.AddLight(new Vector2(player.position.X, player.position.Y), 0.9f, 0.6f, 0.2f);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);
            if (Main.rand.NextFloat() >= 0.5) {
                player.AddBuff(115, 60);
            }
            else {
                player.AddBuff(114, 60);
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            damage = (int)(damage * 2f / 3.5f);
            type = mod.ProjectileType("SunStrike");
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            float randomSpeed = Main.rand.NextFloat() * 0.25f + 1.875f;
            speedX = baseSpeed * randomSpeed * (float)Math.Sin(baseAngle);
            speedY = baseSpeed * randomSpeed * (float)Math.Cos(baseAngle);
            return true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ItemID.BeeKeeper);
            recipe.AddIngredient(null, "Hercules");
            recipe.AddIngredient(null, "Gradience");
            recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
