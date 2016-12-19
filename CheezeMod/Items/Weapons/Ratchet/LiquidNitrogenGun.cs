using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class LiquidNitrogenGun : ModItem
	{
		public override void SetDefaults()
		{
            item.name = "Liquid Nitrogen Gun";
			item.damage = 8;
			item.ranged = true;
			item.width = 50;
			item.height = 30;
            item.scale = 0.875f;
            item.channel = true;
            item.toolTip = "Converts Flares into cold liquid nitrogen.";
            item.toolTip2 = "Originally from Ratchet and Clank: Going Commando.";
            item.useTime = 4;
            item.useAnimation = 12;
			item.useStyle = 5;
            item.channel = true;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 165000;
            item.rare = CheezeItem.ratchetRarity[1];
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/LiquidNitrogenGun");
            item.autoReuse = true;
			item.shoot = mod.ProjectileType("LiquidNitrogenGun");
            item.shootSpeed = 1f;
            item.useAmmo = 931;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("LiquidNitrogenGun");
            return true;
        }

        public override void UpdateInventory(Player player)
        {
            CheezePlayer.sellFlare = true;
            base.UpdateInventory(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LavaGun");
            recipe.AddIngredient(null, "HellstoneBolt", 50);
            recipe.AddIngredient(null, "SapphireLens", 1);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }


        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(9) < 1; // 88.88% not to consume ammo.
        }
    }
}