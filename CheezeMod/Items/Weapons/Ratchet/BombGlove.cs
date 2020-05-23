using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class BombGlove : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 5;
			item.thrown = true;
			item.width = 60;
			item.height = 42;
            item.scale = 0.75f;


            item.useTime = 42;
            item.useAnimation = 42;
			item.useStyle = 1;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 39000;
            item.rare = CheezeItem.ratchetRarity[0];
            item.UseSound = SoundID.Item19;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
			item.useAmmo = ProjectileID.Grenade;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bomb Glove");
      Tooltip.SetDefault("Throw grenades with increased velocity, has a 20% chance not to consume ammo.\nOriginally from Ratchet and Clank. \n*NOTE : If Grenades are buggy, craft them into ammo at the MegaCorp Vendor!");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IronBolt", 50);
            recipe.AddRecipeGroup("CheezeMod:EvilLeather", 10);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 1f; // 1 degrees 
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.X);
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.Y);
            switch (type)
            {
	            case ProjectileID.Grenade:
		            type = mod.ProjectileType("BombGloveGrenade");
		            break;
	            case ProjectileID.StickyGrenade:
		            type = mod.ProjectileType("BombGloveStickyGrenade");
		            break;
	            case ProjectileID.BouncyGrenade:
		            type = mod.ProjectileType("BombGloveBouncyGrenade");
		            break;
	            case ProjectileID.Beenade:
		            type = mod.ProjectileType("BombGloveBeenade");
		            break;
	            default:
		            break;
            }

            return true;
        }
        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(5) < 4; // 20%
        }
    }
}
