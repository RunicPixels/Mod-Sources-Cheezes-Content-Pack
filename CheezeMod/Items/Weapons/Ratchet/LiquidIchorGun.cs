using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
    public class LiquidIchorGun : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Liquid Ichor Gun";
            item.damage = 15;
            item.ranged = true;
            item.width = 50;
            item.height = 30;
            item.scale = 0.875f;
            item.channel = true;
            item.toolTip = "Converts Flares into liquid ichor.";
            item.toolTip2 = "Inspired by Ratchet and Clank: Going Commando.";
            item.useTime = 3;
            item.useAnimation = 9;
            item.useStyle = 5;
            item.channel = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 1;
            item.value = 250000;
            item.rare = 6;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/LiquidNitrogenGun");
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("LiquidIchorGun");
            item.shootSpeed = 1f;
            item.useAmmo = 931;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("LiquidIchorGun");
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LiquidNitrogenGun");
            recipe.AddIngredient(null, "HallowedBolt", 50);
            recipe.AddIngredient(ItemID.LivingIchorBlock, 20);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }


        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(12) == 0; // 93.3% not to consume ammo.
        }
    }
}