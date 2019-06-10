using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class MegaMultistar : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 60;
			item.thrown = true;
			item.width = 38;
            item.scale = 0.6f;
			item.height = 24;


            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 270000;
            item.rare = CheezeItem.ratchetRarity[2];
            item.crit = 8;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Chopper");
            item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 8f;
			item.useAmmo = ProjectileID.Shuriken;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mega Multistar");
      Tooltip.SetDefault("Throw a double splitting shuriken, uses Shuriken as ammo.\nOriginally from Ratchet and Clank: Going Commando.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Multistar");
            recipe.AddIngredient(null, "HallowedBolt", 50);
            recipe.AddIngredient(null, "ShipWreckage", 5);
            recipe.AddIngredient(ItemID.CrystalShard, 5);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("MegaMultistar");
            return true;
        }
    }
}
