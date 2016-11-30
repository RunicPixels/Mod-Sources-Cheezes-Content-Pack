using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class BlitzGun : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Blitz Gun";
			item.damage = 13;
			item.ranged = true;
			item.width = 50;
            item.scale = 0.7f;
			item.height = 34;
			item.toolTip = "Shoots a wide arc of shots, converts normal bullets into Blitz Cannon shots.";
            item.toolTip2 = "Originally from Ratchet and Clank: Going Commando.";
            item.useTime = 42;
            item.useAnimation = 42;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 36000;
			item.rare = 2;
			item.useSound = 11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
			item.useAmmo = ProjectileID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MeteoriteBolt", 50);
            recipe.AddIngredient(null, "TopazLens");
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 30f; // 30 degrees
            float baseX = speedX;
            float baseY = speedY;
            for (int i = 0; i <= 3 + Main.rand.Next(2); i++)
            {

                speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
                speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y'); ;
                if (type == ProjectileID.Bullet || type == mod.ProjectileType("BlitzGun"))
                {
                    type = mod.ProjectileType("BlitzGun");
                    speedX *= 6f;
                    speedY *= 6f;
                    damage *= (int)1.3;
                }
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, item.owner);
                speedX = baseX;
                speedY = baseY;
            }
            type = 0;
            return true;
        }
    }
}