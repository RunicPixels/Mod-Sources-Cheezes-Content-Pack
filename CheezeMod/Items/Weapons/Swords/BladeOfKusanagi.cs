using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace CheezeMod.Items.Weapons.Swords
{
	public class BladeOfKusanagi : ModItem
	{
        DrawAnimationVertical animation;

        public override void SetDefaults()
		{
            item.damage = 70;
			item.melee = true;
            item.noMelee = true;
			item.width = 58;
			item.height = 64;
			item.useAnimation = 14;
            item.useTime = 14;
            item.channel = true;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("BladeOfKusanagi");
            item.knockBack = 5;
			item.value = 50000;
			item.rare = 6;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blade of Kusanagi");
            Tooltip.SetDefault("From 'Ökami'.");
            Main.RegisterItemAnimation(item.type, animation = new DrawAnimationVertical(10, 4));
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
	}
}
