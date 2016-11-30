using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
    public class UltraBombGlove : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ultra Bomb Glove";
            item.damage = 80;
            item.thrown = true;
            item.width = 60;
            item.height = 42;
            item.scale = 0.75f;
            item.toolTip = "Uses grenades, has a 75% chance not to consume ammo.";
            item.toolTip2 = "Insired by Ratchet and Clank.";
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 1;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 750000;
            item.rare = 10;
            item.useSound = 19;
            item.autoReuse = false;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 5f;
            item.autoReuse = true;
            item.useAmmo = ProjectileID.Grenade;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MegaBombGlove");
            recipe.AddIngredient(null, "LuminiteBolt", 50);
            recipe.AddIngredient(ItemID.FeralClaws, 1);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 5f; // 1 degrees 
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            damage = (int)(damage * 0.95f);
            if (type == ProjectileID.Grenade)
            {
                type = ProjectileID.GrenadeIII;
            }
            return true;
        }
        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(4) == 0; // 25%
        }
    }
}