using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CheezeMod.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class LavaGun : ModItem
	{
		public override void SetDefaults()
		{
            item.name = "Lava Gun";
			item.damage = 4;
			item.ranged = true;
			item.width = 50;
			item.height = 30;
            item.scale = 0.875f;
            item.channel = true;
            item.toolTip = "Uses Flares, now also made at the MegaCorp Vendor with Musket Balls.";
            item.toolTip2 = "Originally from Ratchet and Clank: Going Commando.";
            item.useTime = 5;
            item.useAnimation = 10;
			item.useStyle = 5;
            item.channel = true;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 33000;
            item.rare = CheezeItem.ratchetRarity[0];
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/LavaGun");
            item.autoReuse = true;
			item.shoot = mod.ProjectileType("LavaGun");
            item.shootSpeed = 0f;
            item.useAmmo = 931;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("LavaGun");
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MeteoriteBolt", 50);
            recipe.AddIngredient(ItemID.LavaBucket);
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
            return Main.rand.Next(10) < 1; // 90% not to consume ammo.
        }
    }
}