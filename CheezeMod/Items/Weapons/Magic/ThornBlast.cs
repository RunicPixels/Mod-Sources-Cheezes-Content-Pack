using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Magic
{
    public class ThornBlast : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Thorn Blast";
            item.damage = 22;
            item.magic = true;
            item.mana = 12;
            item.width = 40;
            item.height = 40;
            item.toolTip = "Summons a floating ball of thorns that explodes and shoots poisoning thorns after 0.5 second";
            item.channel = true;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 25000;
            item.rare = 2;
            item.UseSound = SoundID.Item8;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ThornBlast");
            item.shootSpeed = 9f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Stinger, 10);
            recipe.AddIngredient(ItemID.JungleSpores, 10);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}