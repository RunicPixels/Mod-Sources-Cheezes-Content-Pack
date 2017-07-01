using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Guns
{
    public class GoldenPiratePistol : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 39;
            item.ranged = true;
            item.width = 40;
            item.height = 24;
            item.scale = 0.8f;

            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 90000;
            item.rare = 5;
            item.crit = 12;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Golden Pirate Pistol");
      Tooltip.SetDefault("Converts Musket Balls and Silver Bullets into Ichor Bullets.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlintlockPistol);
            recipe.AddIngredient(ItemID.Ichor, 5);
            recipe.AddIngredient(ItemID.Shadewood, 5);
            recipe.AddIngredient(null, "ShipWreckage", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                    type = ProjectileID.IchorBullet;
            }
            return true;
        }
    }
}
