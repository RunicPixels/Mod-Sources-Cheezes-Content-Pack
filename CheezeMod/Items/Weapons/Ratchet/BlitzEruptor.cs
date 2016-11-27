using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class BlitzEruptor : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Blitz Eruptor";
			item.damage = 36;
			item.ranged = true;
			item.width = 50;
            item.scale = 0.8f;
			item.height = 38;
			item.toolTip = "Is able to inflict enemies with cursed or shadow flames, converts normal bullets into Mega Blitz Eruptor shots.";
            item.toolTip2 = "Inspired by from Ratchet and Clank: Going Commando.";
            item.useTime = 34;
            item.useAnimation = 34;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 270000;
			item.rare = 6;
			item.useSound = 11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
			item.useAmmo = ProjectileID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BlitzCannon");
            recipe.AddIngredient(null, "HallowedBolt", 50);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SpiderFang, 3);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 25f; // 25 degrees
            for (int i = 0; i <= 4 + Main.rand.Next(4); i++)
            {
                speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
                speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
                if (type == ProjectileID.Bullet || type == mod.ProjectileType("BlitzEruptor"))
                {
                    type = mod.ProjectileType("BlitzEruptor");
                    speedX *= 6f;
                    speedY *= 6f;
                    damage *= (int)1.1;
                }
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, item.owner);
            }
            return true;
        }
    }
}