using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;
using Microsoft.Xna.Framework.Graphics;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class HellstoneKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);
			item.name = "Hellstone Kunai";
			item.damage = 29;
			item.thrown = true;
            item.noMelee = true;
			item.width = 18;
			item.height = 38;
            item.autoReuse = true;
            item.toolTip = "It has a tag on its handle which reads 'Kazan', it's from a far eastern place.";
            item.toolTip2 = "It has a 10% chance to put your enemy on fire.";
            item.useTime = 21;
			item.useAnimation = 21;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 8000;
            item.rare = 3;
			item.shoot = mod.ProjectileType("HellstoneKunai");
			item.shootSpeed = 14f;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 27);
			recipe.AddRecipe();
		}

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Lighting.AddLight(new Vector2(item.position.X, item.position.Y), 0.4f, 0.3f, 0.2f);
        }
    }
}