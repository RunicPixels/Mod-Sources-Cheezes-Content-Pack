using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
    public class GuardianSword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Guardian Sword";
            item.damage = 25;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.toolTip = "A sword used by the guardians of Madrigal. \n+14% Critical Chance. \n+6% Increased Critical Damage. \n+10% Movement Speed when hold.";
            item.crit = 14;
            item.scale = 1.2f;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = CheezeItem.guardianPrice;
            item.rare = CheezeItem.guardianRarity;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
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
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.06f; // This number here changes the multiplier
                player.maxRunSpeed *= 1.1f;
                player.jumpSpeedBoost *= 1.1f;
            }
        }
    }
}