using System;
using CheezeMod.Items.Vanilla;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ammo
{
    public class BombGloveGrenade : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Grenade);
            item.ammo = ProjectileID.Grenade;
            item.shoot = mod.ProjectileType("BombGloveGrenade");
            item.width = 14;
            item.height = 14;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bomb Glove Grenade");
            Tooltip.SetDefault("Use these if default grenades don't work with the Bomb Glove.");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
