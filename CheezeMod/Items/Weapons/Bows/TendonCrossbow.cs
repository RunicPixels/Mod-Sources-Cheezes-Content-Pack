using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Bows
{
	public class TendonCrossbow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Tendon Crossbow";
			item.damage = 24;
			item.ranged = true;
			item.width = 52;
			item.height = 20;
            item.toolTip = "Sometimes turns Wooden arrows into Unholy arrows.";
            item.toolTip2 = "Shoots 3 arrows with a random spread and speed, 25% not to consume ammo.";
            item.useTime = 5;
            item.reuseDelay = 40;
            item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 50000;
			item.rare = 3;
            item.crit = 4;
			item.useSound = 5;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 8f;
			item.useAmmo = ProjectileID.WoodenArrowFriendly;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(796); // 796 = Tendon Crossbow
            recipe.AddIngredient(null, "GraniteShard", 15);
            recipe.AddIngredient(3294); // 3294 = Orange String
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(796); // 796 = Tendon Crossbow
            recipe.AddIngredient(null, "GraniteShard", 15);
            recipe.AddIngredient(3295); // 3295 = Yellow String
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 8f * 0.0174f;//8 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
            float randomSpeed = Main.rand.NextFloat() * 0.5f + 0.75f;
            speedX = baseSpeed * randomSpeed * (float)Math.Sin(randomAngle);
            speedY = baseSpeed * randomSpeed * (float)Math.Cos(randomAngle);
            if (type == 1)
            {
                if (Main.rand.Next(5) <= 0) // 1/5 chance to become a Unholy Arrow
                {
                    type = 4;
                }
            }
            return true;
        }

        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(4) < 3; //25%
        }
    }
}