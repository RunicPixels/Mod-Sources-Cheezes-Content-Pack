using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;
using Microsoft.Xna.Framework.Graphics;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class HallowedKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);
			item.name = "Hallowed Kunai";
			item.damage = 56;
			item.thrown = true;
            item.noMelee = true;
			item.width = 18;
			item.height = 38;
            item.autoReuse = true;
            item.toolTip = "It has a tag on its handle which reads 'Hikari', it's from a far eastern place.";
            item.toolTip2 = "It has a 10% chance to grant either shine or regeneration effect for 5 seconds on the player on enemy hit.";
            item.useTime = 19;
			item.useAnimation = 19;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 12000;
            item.rare = 5;
			item.shoot = mod.ProjectileType("HallowedKunai");
			item.shootSpeed = 21f;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 37);
			recipe.AddRecipe();
		}

        /*public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
                {
                    Lighting.AddLight(new Vector2(item.position.X, item.position.Y), 0.4f, 0.4f, 0.2f);
                } Broken in latest version */
    }
}