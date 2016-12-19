using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class UltraHeavyBouncer : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ultra Heavy Bouncer";
			item.damage = 100;
			item.ranged = true;
			item.width = 66;
			item.height = 42;
            item.scale = 0.8f;
            item.toolTip = "Uses bullets, shoots a double splitting ball that inflicts frostburn.";
            item.toolTip2 = "Inspired by Ratchet and Clank: Going Commando.";
            item.useTime = 46;
            item.useAnimation = 46;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 1000000;
            item.rare = CheezeItem.ratchetRarity[3];
            item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 4f;
			item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MegaHeavyBouncer");
            recipe.AddIngredient(null, "LuminiteBolt", 50);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 30);
            recipe.AddIngredient(ItemID.Nanites, 15);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 1f; // 1 degrees
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            type = mod.ProjectileType("UltraHeavyBouncer");
            return true;
        }
    }
}