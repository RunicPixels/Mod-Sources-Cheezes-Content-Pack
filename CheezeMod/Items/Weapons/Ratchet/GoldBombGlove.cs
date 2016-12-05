using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class GoldBombGlove : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Gold Bomb Glove";
			item.damage = 20;
			item.thrown = true;
			item.width = 60;
			item.height = 42;
            item.scale = 0.75f;
            item.toolTip = "Uses grenades, has a 25% chance not to consume ammo.";
            item.toolTip2 = "Originally from Ratchet and Clank.";
            item.useTime = 32;
            item.useAnimation = 32;
			item.useStyle = 1;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 120000;
			item.rare = 3;
            item.UseSound = SoundID.Item19;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
			item.useAmmo = ProjectileID.Grenade;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BombGlove");
            recipe.AddIngredient(null, "HellstoneBolt", 50);
            recipe.AddRecipeGroup("CheezeMod:GoldBars", 5);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 1f; // 1 degrees 
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            damage = (int)(damage * 0.75f);
            if (type == ProjectileID.Grenade)
            {
                type = ProjectileID.GrenadeI;
            }
            return true;
        }
        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(4) < 3; // 20%
        }
    }
}