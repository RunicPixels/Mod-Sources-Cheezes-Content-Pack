using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Bows
{
    public class AngelBow : ModItem
    {
        int mode = 0;
        public override void SetDefaults()
        {
            item.name = "Angel Bow";
            item.damage = 45;
            item.ranged = true;
            item.width = 28;
            item.height = 56;
            item.toolTip = "A bow that once used by the angels of Madrigal. \n+18% Critical Chance. \n+25% Increased Critical Damage. \n+Autofires.\n Inflics Angels's Bane on enemy hit.";
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;
            item.scale = 1f;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4;
            item.value = CheezeItem.angelPrice;
            item.rare = CheezeItem.angelRarity;
            item.crit = 18;
            item.autoReuse = true;
            item.UseSound = SoundID.Item5;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AngelEssence", 5);
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.25f; // This number here changes the multiplier
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).flyffangelic = true; // Dryad debuff on enemy for 1 sec.
            }
        }
    }
}