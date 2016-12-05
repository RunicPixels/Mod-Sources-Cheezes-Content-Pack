using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Bows
{
	public class TrueVolcanoCrossbow : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.MoltenFury);
            item.name = "True Volcano Crossbow";
			item.damage = 42;
			item.ranged = true;
			item.width = 58;
			item.height = 24;
			item.toolTip = "Turns wooden arrows into flaming or even hellfire arrows.";
            item.toolTip2 = "Shoots 6 arrows with a large random spread and speed, consumes only 2";
            item.useTime = 3;
            item.reuseDelay = 30;
            item.useAnimation = 6;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 250000;
			item.rare = 3;
            item.crit = 5;
            item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "VolcanoCrossbow");
            recipe.AddIngredient(null, "RavagedHeroBow");
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            for (int i = 0; i < 3; i++)
            {
                float spread = 16f; // 16 degrees
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
                else if (type == 2) // If flaming arrow
                {
                    if (Main.rand.Next(2) <= 0) // 1/2 chance to become a hellfire arrow
                    {
                        type = 41;
                    }
                }
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, item.owner);
            }
            ConsumeAmmo(player);
            return false;
        }
    }
}