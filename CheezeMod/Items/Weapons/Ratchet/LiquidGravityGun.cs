using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
    public class LiquidGravityGun : ModItem
    {
        public uint ammoCounter = 0;
        public override void SetDefaults()
        {
            item.name = "Liquid Gravity Gun";
            item.damage = 30;
            item.ranged = true;
            item.width = 64;
            item.height = 30;
            item.scale = 0.8f;
            item.channel = true;
            item.toolTip = "Converts Flares into liquid gravity, which inflicts shadow flames, ichor and pulls your enemies dow..";
            item.toolTip2 = "Inspired by Ratchet and Clank: Going Commando.";
            item.useTime = 2;
            item.useAnimation = 8;
            item.useStyle = 5;
            item.channel = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 1;
            item.value = 640000;
            item.rare = 10;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/LiquidNitrogenGun");
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("LiquidGravityGun");
            item.shootSpeed = 1f;
            item.useAmmo = 931;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("LiquidGravityGun");
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LiquidIchorGun");
            recipe.AddIngredient(null, "LuminiteBolt", 50);
            recipe.AddIngredient(ItemID.PortalGun);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LiquidCursedFlameGun");
            recipe.AddIngredient(null, "LuminiteBolt", 50);
            recipe.AddIngredient(ItemID.PortalGun);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }


        public override bool ConsumeAmmo(Player p)
        {
            ammoCounter++;
            return ammoCounter % 15 == 0; // 93.3% not to consume ammo.
        }
    }
}