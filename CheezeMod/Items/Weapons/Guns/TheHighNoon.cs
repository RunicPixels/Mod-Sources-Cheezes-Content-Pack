using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Guns
{
    public class TheHighNoon : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "The High Noon";
            item.damage = 44;
            item.ranged = true;
            item.width = 48;
            item.height = 26;
            item.scale = 0.7f;
            item.toolTip = "'It's high noon.' This weapon is a reference from McCree from Overwatch.";
            item.toolTip2 = "Alternative fire (Default: Right Mouse Button) shoots 6 bullets in rapid fashion.";
            item.useTime = 5;
            item.useAnimation = item.useTime;
            item.reuseDelay = 3;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4;
            item.value = 180000;
            item.rare = 5;
            item.crit = 8;
            item.useSound = 0;
            item.autoReuse = false;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 14f;
            item.useAmmo = ProjectileID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
            recipe.AddIngredient(ItemID.AntlionMandible, 5);
            recipe.AddIngredient(ItemID.Cactus, 25);
            recipe.AddIngredient(null, "ShipWreckage", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(2, player.position, 11);
            float spread = 0f;
            if (player.altFunctionUse == 2)
            {
                spread = 20f * 0.0174f; // 20 degrees converted to radians
            }
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
            speedX = baseSpeed * (float)Math.Sin(randomAngle);
            speedY = baseSpeed * (float)Math.Cos(randomAngle);
            item.useAnimation = item.useTime;
            item.reuseDelay = item.useTime;
            return true;
        }
        public override bool AltFunctionUse(Player player)
        {
            item.useAnimation = 6 * item.useTime;
            item.reuseDelay = 9 * item.useTime;
            return true;
        }
    }
}