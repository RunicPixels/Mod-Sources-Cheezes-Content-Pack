using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;
using Microsoft.Xna.Framework.Graphics;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class MeteoriteKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);
			item.name = "Meteorite Kunai";
			item.damage = 24;
			item.thrown = true;
            item.noMelee = true;
			item.width = 18;
			item.height = 38;
            item.autoReuse = true;
            item.toolTip = "It has a tag on its handle which reads 'Ryuusei', it's from a far eastern place.";
            item.toolTip2 = "It has a 25% chance to summon a meteor on hit.";
            item.useTime = 21;
			item.useAnimation = 21;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 7500;
            item.rare = 2;
			item.shoot = mod.ProjectileType("MeteoriteKunai");
			item.shootSpeed = 14f;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 27);
			recipe.AddRecipe();
		}

        /*public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
                {
                    Lighting.AddLight(new Vector2(item.position.X, item.position.Y), 0.4f, 0.3f, 0.2f);
                } Broken in latest version */
    }
}