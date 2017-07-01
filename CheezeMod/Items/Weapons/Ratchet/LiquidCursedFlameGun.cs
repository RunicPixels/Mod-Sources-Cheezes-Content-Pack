using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class LiquidCursedFlameGun : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.ranged = true;
			item.width = 50;
			item.height = 30;
            item.scale = 0.875f;
            item.channel = true;


            item.useTime = 3;
            item.useAnimation = 9;
			item.useStyle = 5;
            item.channel = true;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 250000;
            item.rare = CheezeItem.ratchetRarity[2];
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/LiquidNitrogenGun");
            item.autoReuse = true;
			item.shoot = mod.ProjectileType("LiquidCursedFlameGun");
            item.shootSpeed = 1f;
            item.useAmmo = 931;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Liquid Cursed Flame Gun");
      Tooltip.SetDefault("Converts Flares into liquid cursed flames.\ninspired by Ratchet and Clank: Going Commando.");
    }


        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("LiquidCursedFlameGun");
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LiquidNitrogenGun");
            recipe.AddIngredient(null, "HallowedBolt", 50);
            recipe.AddIngredient(ItemID.LivingCursedFireBlock, 20);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void UpdateInventory(Player player)
        {
            CheezePlayer.sellFlare = true;
            base.UpdateInventory(player);
        }

        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(12) == 0; // 93.3% not to consume ammo.
        }
    }
}
