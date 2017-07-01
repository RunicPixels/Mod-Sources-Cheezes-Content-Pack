using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class Chopper : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.thrown = true;
			item.width = 38;
            item.scale = 0.6f;
			item.height = 24;


            item.useTime = 45;
            item.useAnimation = 45;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 31000;
            item.rare = CheezeItem.ratchetRarity[0];
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Chopper");
            item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 7f;
			item.useAmmo = ProjectileID.Shuriken;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Chopper");
      Tooltip.SetDefault("Not a Tanuki! Throw a bouncing shuriken, uses Shuriken as ammo.\nOriginally from Ratchet and Clank: Going Commando.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MeteoriteBolt", 50);
            recipe.AddIngredient(null, "GraniteShard", 5);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("Chopper");
            return true;
        }
    }
}
