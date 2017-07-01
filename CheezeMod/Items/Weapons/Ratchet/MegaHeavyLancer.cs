using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class MegaHeavyLancer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 36;
			item.ranged = true;
			item.width = 64;
			item.height = 30;
            item.scale = 0.8f;


            item.useTime = 8;
            item.useAnimation = 8;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 560000;
            item.rare = CheezeItem.ratchetRarity[2];
            item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mega Heavy Lancer");
      Tooltip.SetDefault("'My barrel runs hot!', 44% Chance not to consume ammo. Converts normal bullets into Mega Heavy Lancer shots which inflict flames and midas.\nOriginally from Ratchet and Clank: Going Commando.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HeavyLancer");
            recipe.AddIngredient(null, "HallowedBolt", 50);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.GoldDust, 10);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 5f; // 4 degrees converted to radians
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("MegaHeavyLancer");
                damage *= (int)1.1;
            }
            return true;
        }

        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(9) < 5; // 44.44%
        }
    }
}
