using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class MiniNuke : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 64;
			item.ranged = true;
			item.width = 56;
			item.height = 40;
            item.scale = 1f;


            item.useTime = 55;
            item.useAnimation = 55;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 12;
			item.value = 640000;
            item.rare = CheezeItem.ratchetRarity[1];
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/GravityBomb");
            item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 7f;
			item.useAmmo = AmmoID.Rocket;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mini Nuke");
      Tooltip.SetDefault("Uses rockets, shoots an exploding nuke.\nOriginally from Ratchet and Clank: Going Commando.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HellstoneBolt", 50);
            recipe.AddIngredient(null, "GravityBomb");
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 1f; // 1 degrees 
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            type = mod.ProjectileType("MiniNuke");
            return true;
        }
    }
}
