using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class UltraNuke : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 200;
			item.ranged = true;
			item.width = 60;
			item.height = 40;
            item.scale = 0.9f;
            item.useTime = 60;
            item.useAnimation = 60;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 20;
			item.value = 3640000;
            item.rare = CheezeItem.ratchetRarity[3];
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/GravityBomb");
            item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 9f;
			item.useAmmo = AmmoID.Rocket;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultra Nuke");
            Tooltip.SetDefault("Uses rockets, shoots an exploding, 'Extreme Radiation' inflicting nuke.\nOriginally from Ratchet and Clank: Going Commando.");
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LuminiteBolt", 50);
            recipe.AddIngredient(null, "MegaNuke");
            recipe.AddIngredient(ItemID.ShroomiteBar, 5);
            recipe.AddIngredient(null, "Antimatter", 2);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 1f; // 1 degrees 
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            type = mod.ProjectileType("UltraNuke");
            return true;
        }
    }
}
