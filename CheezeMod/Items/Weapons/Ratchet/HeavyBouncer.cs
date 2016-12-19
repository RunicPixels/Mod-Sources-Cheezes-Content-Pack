using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class HeavyBouncer : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Heavy Bouncer";
			item.damage = 35;
			item.ranged = true;
			item.width = 66;
			item.height = 42;
            item.scale = 0.75f;
            item.toolTip = "Uses bullets, shoots a splitting ball.";
            item.toolTip2 = "Originally from Ratchet and Clank: Going Commando.";
            item.useTime = 50;
            item.useAnimation = 50;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 195000;
            item.rare = CheezeItem.ratchetRarity[1];
            item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
			item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Bouncer");
            recipe.AddIngredient(null, "HellstoneBolt", 50);
            recipe.AddIngredient(ItemID.SpikyBall, 30);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 1f; // 1 degrees 
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            type = mod.ProjectileType("HeavyBouncer");
            return true;
        }
    }
}