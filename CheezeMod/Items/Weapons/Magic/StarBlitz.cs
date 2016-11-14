using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Magic
{
    public class StarBlitz : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Star Blitz";
            item.damage = 12;
            item.magic = true;
            item.mana = 3;
            item.width = 40;
            item.height = 40;
            item.toolTip = "Summons a shower of stars.";
            item.channel = true;
            item.useTime = 7;
            item.useAnimation = 7;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 25000;
            item.rare = 2;
            item.useSound = 9;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("StarStorm");
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "StarlightBar", 12);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 20f * 0.0174f;//20 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
            float randomSpeed = Main.rand.NextFloat() * 0.5f + 0.75f;
            speedX = baseSpeed * randomSpeed * (float)Math.Sin(randomAngle);
            speedY = baseSpeed * randomSpeed * (float)Math.Cos(randomAngle);
            return true;
        }
    }
}