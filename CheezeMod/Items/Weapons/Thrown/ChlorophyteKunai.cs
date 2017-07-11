using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;
using Microsoft.Xna.Framework.Graphics;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class ChlorophyteKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);

			item.damage = 55;
			item.thrown = true;
            item.noMelee = true;
			item.width = 18;
			item.height = 38;
            item.autoReuse = true;
            item.useTime = 26;
			item.useAnimation = 26;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 12500;
            item.rare = 6;
			item.shoot = mod.ProjectileType("ChlorophyteKunai");
			item.shootSpeed = 16f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Chlorophyte Kunai");
      Tooltip.SetDefault("It has a tag on its handle which reads 'Hikari', it's from a far eastern place.\nIt throws three kunais while always using only one, has a 10% chance to poison your enemies for 6 seconds.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 37);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.ConsumeItem(item.type);
            float spread = 5f * 0.0174f; // 5 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double[] Angle = { baseAngle + -1 * spread, baseAngle + 0 * spread, baseAngle + 1 * spread };
            float[] speedXArray = { baseSpeed * (float)Math.Sin(Angle[0]), baseSpeed * (float)Math.Sin(Angle[1]), baseSpeed * (float)Math.Sin(Angle[2]) };
            float[] speedYArray = { baseSpeed * (float)Math.Cos(Angle[0]), baseSpeed * (float)Math.Cos(Angle[1]), baseSpeed * (float)Math.Cos(Angle[2]) };
            for (int i = 0; i < speedXArray.Length; i++)
            {
               Projectile.NewProjectile(position.X, position.Y, speedXArray[i], speedYArray[i], type, damage, knockBack, item.owner);
            }
            return true;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Lighting.AddLight(new Vector2(item.position.X, item.position.Y), 0.2f, 0.4f, 0.2f);
        }
    }
}
