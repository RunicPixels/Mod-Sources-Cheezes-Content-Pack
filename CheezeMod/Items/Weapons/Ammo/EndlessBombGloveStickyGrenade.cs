using System;
using CheezeMod.Items.Vanilla;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ammo
{
    public class EndlessBombGloveStickyGrenade : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ModContent.ItemType<BombGloveStickyGrenade>());
            item.consumable = false;
            item.rare = 1;
            item.value = 100 * CheezeConfig.Instance.EndlessAmmoAmount;
            item.maxStack = 1;
            item.width = 18;
            item.height = 18;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Bomb Glove Sticky Grenade");
            Tooltip.SetDefault("Use these if default sticky grenades don't work with the Bomb Glove. \nEndless Ammo");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BombGloveStickyGrenade>(), CheezeConfig.Instance.EndlessAmmoAmount);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
