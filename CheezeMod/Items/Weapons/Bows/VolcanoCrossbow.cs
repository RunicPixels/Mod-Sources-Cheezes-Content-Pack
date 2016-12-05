using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Bows
{
	public class VolcanoCrossbow : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.MoltenFury);
            item.name = "Volcano Crossbow";
			item.damage = 31;
			item.ranged = true;
			item.width = 52;
			item.height = 20;
			item.toolTip = "Turns wooden arrows into flaming or even hellfire arrows.";
            item.toolTip2 = "Shoots 4 arrows with a large random spread and speed, 33% not to consume ammo.";
            item.useTime = 3;
            item.reuseDelay = 45;
            item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 250000;
			item.rare = 3;
            item.crit = 4;
            item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 9f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3019); // 3019 is Hellwing Bow
            recipe.AddIngredient(null, "DemonCrossbow");
            recipe.AddIngredient(null, "ObsidianString");
            recipe.AddTile(77);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(3019); // 3019 is Hellwing Bow
            recipe.AddIngredient(null, "TendonCrossbow");
            recipe.AddIngredient(null, "ObsidianString");
            recipe.AddTile(77);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 12.5f; // 12.5 degrees
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            if (type == 1) // If normal wooden arrow
            {
                if (Main.rand.Next(3) <= 0) // 1/3 chance to become a hellfire arrow
                {
                    type = 41;
                }
                else // 2/3 chance to become a flaming arrow
                {
                    type = 2;

                }
            }
            else if(type == 2) // If flaming arrow
            {
                if (Main.rand.Next(2) <= 0) // 1/2 chance to become a hellfire arrow
                {
                    type = 41;
                }
            }
            return true;
        }

        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(3) < 1; // 66% chance not to consume ammo.
        }
    }
}