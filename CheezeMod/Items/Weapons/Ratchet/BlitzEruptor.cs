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

			item.damage = 31;
			item.ranged = true;
			item.width = 50;
            item.scale = 0.8f;
			item.height = 38;


            item.useTime = 29;
            item.useAnimation = 29;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 270000;
            item.rare = CheezeItem.ratchetRarity[2];
            item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
			item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mega Blitz Eruptor");
      Tooltip.SetDefault("Is able to inflict enemies with cursed or shadow flames, converts normal bullets into Mega Blitz Eruptor shots.\nInspired by from Ratchet and Clank: Going Commando.");
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
            float baseX = speedX;
            float baseY = speedY;
            for (int i = 0; i <= 4 + Main.rand.Next(4); i++)
            {
                speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.X);
                speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.Y);
                if (type == ProjectileID.Bullet || type == mod.ProjectileType("BlitzEruptor"))
                {
                    type = mod.ProjectileType("BlitzEruptor");
                    speedX *= 6f;
                    speedY *= 6f;
                    damage *= (int)1.1;
                }
                int projectile = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
                Main.projectile[projectile].netUpdate = true;
                speedX = baseX;
                speedY = baseY;
            }
            type = 0;
            return true;
        }
    }
}
