using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class Lancer : ModItem
	{
		private float spread = 2.55f; // 2.55 degrees
		public override void SetDefaults()
		{

			item.damage = 8;
			item.ranged = true;
			item.width = 38;
            item.scale = 0.8f;
			item.height = 24;


            item.useTime = 13;
            item.useAnimation = 13;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 30000;
            item.rare = CheezeItem.ratchetRarity[0];
            item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 6f;
			item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Lancer");
      Tooltip.SetDefault("'Megacorp's finest.' 11% Chance not to consume ammo. Converts normal bullets into Lancer shots.\nOriginally from Ratchet and Clank: Going Commando.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MeteoriteBolt", 50);
            recipe.AddIngredient(ItemID.AntlionMandible, 5);
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
                type = mod.ProjectileType("Lancer");
                damage *= (int)1.4;
            }
            return true;
        }

        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(9) < 8; // 11.11%
        }
    }
}
