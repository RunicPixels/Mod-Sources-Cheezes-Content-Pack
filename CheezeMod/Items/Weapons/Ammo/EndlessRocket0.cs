using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ammo
{
    public class EndlessRocket0 : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ModContent.ItemType<Rocket0>());
            item.value = 300 * CheezeConfig.Instance.EndlessAmmoAmount;
            item.rare = 1;
            item.consumable = false;
            item.maxStack = 1;
            item.ammo = AmmoID.Rocket;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Endless Rocket 0");
      Tooltip.SetDefault("A low tier rocket.\nIt doesn't do much damage on it's own, but at least you have ammo now.\n Infinite Variant");
    }

        public override void AddRecipes()
        {
            if (CheezeConfig.Instance.EndlessAmmoRecipes)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "Rocket0", CheezeConfig.Instance.EndlessAmmoAmount);
                recipe.AddTile(TileID.WorkBenches);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}
