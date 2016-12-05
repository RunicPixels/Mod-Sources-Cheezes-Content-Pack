using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Bows
{
    public class MushwoodBow : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Mushwood Bow";
            item.damage = 9;
            item.ranged = true;
            item.width = 18;
            item.height = 42;
            item.toolTip = "Is this bow alive?";
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = 1000;
            item.rare = 0;
            item.crit = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 7f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Mushwood", 10);
            recipe.AddTile(18);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}