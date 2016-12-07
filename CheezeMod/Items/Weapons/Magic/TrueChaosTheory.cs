using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Magic
{
    public class TrueChaosTheory : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "True Chaos Theory";
            item.damage = 70;
            item.magic = true;
            item.mana = 12;
            item.width = 40;
            item.height = 40;
            item.toolTip = "Nature has gone to true chaos.";
            item.toolTip = "Spells gain aditional effects compared to the default Chaos Theory. \nThe Spells are:\nInferno Blast.\nWaterfall Bolt\nTriple Wind Strike\nand Earth Avalanche";
            item.channel = true;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 250000;
            item.rare = 8;
            item.UseSound = SoundID.Item8;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("HugeEarthBoulder");
            item.shootSpeed = 9f;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 2f; // 2 degrees
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            if (Main.rand.Next(4) == 0)
            {
                type = mod.ProjectileType("HugeEarthBoulder");
                damage = (int)(damage * 0.8);
            }
            else if (Main.rand.Next(3) == 0)
            {
                type = mod.ProjectileType("InfernoFireBlast");
            }
            else if (Main.rand.Next(2) == 0)
            {
                type = type = mod.ProjectileType("SprayWaterBlast");
                damage = (int)(damage * 0.8);
            }
            else
            {
                baseSpeed *= 1.2f;
                float spreadWind = 15f * 0.0174f; // 5 degrees converted to radians
                double[] Angle = { baseAngle + -1 * spreadWind, baseAngle + 0 * spreadWind, baseAngle + 1 * spreadWind };
                float[] speedXArray = { baseSpeed * (float)Math.Sin(Angle[0]), baseSpeed * (float)Math.Sin(Angle[1]), baseSpeed * (float)Math.Sin(Angle[2]) };
                float[] speedYArray = { baseSpeed * (float)Math.Cos(Angle[0]), baseSpeed * (float)Math.Cos(Angle[1]), baseSpeed * (float)Math.Cos(Angle[2]) };
                for (int i = 0; i <= speedXArray.Length; i++)
                {
                    Projectile.NewProjectile(position.X, position.Y, speedXArray[i], speedYArray[i], mod.ProjectileType("WindBlast"), (int)(damage * 0.65), knockBack, item.owner);
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ChaosTheory");
            recipe.AddIngredient(null, "TornHeroBook");
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}