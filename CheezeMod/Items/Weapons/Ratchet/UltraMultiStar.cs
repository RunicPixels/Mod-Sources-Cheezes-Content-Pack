using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class UltraMultistar : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ultra Multistar";
			item.damage = 90;
			item.thrown = true;
			item.width = 38;
            item.scale = 0.6f;
			item.height = 24;
			item.toolTip = "Throw a triple splitting shuriken, uses Shuriken as ammo.";
            item.toolTip2 = "Originally from Ratchet and Clank: Going Commando.";
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 770000;
			item.rare = 10;
            item.crit = 6;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Chopper");
            item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 9f;
			item.useAmmo = ProjectileID.Shuriken;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MegaMultistar");
            recipe.AddIngredient(null, "LuminiteBolt", 50);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddIngredient(ItemID.Actuator, 40);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("UltraMultistar");
            return true;
        }
    }
}