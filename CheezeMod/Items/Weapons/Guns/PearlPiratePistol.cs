using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Guns
{
    public class PearlPiratePistol : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Pearl Pirate Pistol";
            item.damage = 35;
            item.ranged = true;
            item.width = 40;
            item.height = 24;
            item.scale = 0.8f;
            item.toolTip = "Converts Musket Balls and Silver Bullets into Crystal Bullets.";
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 90000;
            item.rare = 5;
            item.crit = 12;
            item.useSound = 11;
            item.autoReuse = false;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 15f;
            item.useAmmo = ProjectileID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlintlockPistol);
            recipe.AddIngredient(ItemID.CrystalShard, 5);
            recipe.AddIngredient(ItemID.Pearlwood, 5);
            recipe.AddIngredient(null, "ShipWreckage", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                    type = ProjectileID.CrystalBullet;
            }
            return true;
        }
    }
}