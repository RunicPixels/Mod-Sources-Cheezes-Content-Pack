using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Magic
{
    public class ChaosTheory : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 40;
            item.magic = true;
            item.mana = 9;
            item.width = 40;
            item.height = 40;


            item.channel = true;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 25000;
            item.rare = 3;
            item.UseSound = SoundID.Item8;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EarthBoulder");
            item.shootSpeed = 9f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Chaos Theory");
      Tooltip.SetDefault("Nature has gone to chaos.\nShoots 4 different elemental spells at random. \nThe Spells are:\nFire Blast.\nWater Bolt\nWind Strike\nand Earth Boulder");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StarBlitz");
            recipe.AddIngredient(ItemID.FlowerofFire);
            recipe.AddIngredient(null, "ThornBlast");
            recipe.AddIngredient(ItemID.WaterBolt);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            base.AddRecipes();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 2f; // 2 degrees
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            if (Main.rand.Next(4) == 0)
            {
                type = mod.ProjectileType("EarthBoulder");
                damage = (int)(damage * 0.8);
                speedX = speedX * 1.2f;
                speedY = speedY * 1.2f;
            }
            else if (Main.rand.Next(3) == 0)
            {
                type = mod.ProjectileType("FireBlast");
                damage = (int)(damage * 1.2);
            }
            else if (Main.rand.Next(2) == 0)
            {
                type = type = mod.ProjectileType("WaterBlast");
                damage = (int)(damage * 0.8);
            }
            else
            {
                type = mod.ProjectileType("WindBlast");
                speedX = speedX * 1.2f;
                speedY = speedY * 1.2f;
            }
            return true;
        }
    }
}
