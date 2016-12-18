using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
    public class UltraBlitzEruptor : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ultra Blitz Eruptor";
            item.damage = 78;
            item.ranged = true;
            item.width = 50;
            item.scale = 0.8f;
            item.height = 38;
            item.toolTip = "Is able to inflict enemies with frost-, normal- or shadow flames, converts normal bullets into Ultra Blitz Eruptor shots.";
            item.toolTip2 = "Inspired by from Ratchet and Clank: Going Commando.";
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 540000;
            item.rare = 10;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 3f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BlitzEruptor");
            recipe.AddIngredient(null, "LuminiteBolt", 50);
            recipe.AddIngredient(ItemID.IllegalGunParts, 2);
            recipe.AddIngredient(ItemID.FragmentNebula, 5);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 25f; // 25 degrees
            float baseX = speedX;
            float baseY = speedY;
            for (int i = 0; i <= 5 + Main.rand.Next(5); i++)
            {

                speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
                speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
                if (type == ProjectileID.Bullet || type == mod.ProjectileType("UltraBlitzEruptor"))
                {
                    type = mod.ProjectileType("UltraBlitzEruptor");
                    speedX *= 6f;
                    speedY *= 6f;
                    damage *= (int)1.1;
                }
                int projectile = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, item.owner);
                Main.projectile[projectile].netUpdate = true;
                speedX = baseX;
                speedY = baseY;
            }
            type = 0;
            return true;
        }
    }
}