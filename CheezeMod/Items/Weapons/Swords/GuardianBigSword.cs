using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
    public class GuardianBigSword : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 42;
            item.melee = true;
            item.width = 54;
            item.height = 54;

            item.crit = 15;
            item.scale = 1.25f;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = CheezeItem.guardianPrice;
            item.rare = CheezeItem.guardianRarity;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Guardian Big Sword");
      Tooltip.SetDefault("A two handed sword used by the guardians of Madrigal. \n+15% Critical Chance. \n+15 HP when holding. \n+3 Defense when holding.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddRecipeGroup("CheezeMod:EvilSwords");
            recipe.AddTile(18);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(20) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 55);
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                player.statLifeMax2 += 15;
                player.statDefense += 3;
            }
        }
    }
}
