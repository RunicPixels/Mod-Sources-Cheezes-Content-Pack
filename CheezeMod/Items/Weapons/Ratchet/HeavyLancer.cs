using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class HeavyLancer : ModItem
	{
		float spread = 5f; // 5 degrees
		public override void SetDefaults()
		{

			item.damage = 15;
			item.ranged = true;
			item.width = 64;
			item.height = 30;
            item.scale = 0.8f;


            item.useTime = 9;
            item.useAnimation = 9;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 150000;
            item.rare = CheezeItem.ratchetRarity[1];
            item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 7f;
			item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Heavy Lancer");
      Tooltip.SetDefault("'My barrel runs hot!', 22% Chance not to consume ammo. Converts normal bullets into Heavy Lancer shots.\nOriginally from Ratchet and Clank: Going Commando.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Lancer");
            recipe.AddIngredient(null, "HellstoneBolt", 50);
            recipe.AddIngredient(null, "FlameWing", 15);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.X);
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.Y);
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("HeavyLancer");
                damage *= (int)1.3;
            }
            return true;
        }

        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(9) < 7; // 22.22%
        }
    }
}
