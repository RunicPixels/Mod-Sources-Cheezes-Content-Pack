using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
    public class HistoricBigSword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Historic Big Sword";
            item.damage = 62;
            item.melee = true;
            item.width = 78;
            item.height = 78;
            item.toolTip = "An two handed sword that is an historic artifact of Madrigal. \n+15% Critical Chance. \n+15 HP when holding. \n+5 Defense when holding. \nInflicts enemies with Dryad's Bane.";
            item.crit = 15;
            item.scale = 1f;
            item.useTime = 38;
            item.useAnimation = 38;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = CheezeItem.historicPrice;
            item.rare = 4;
            item.useSound = 1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HistoricEssence", 5);
            recipe.AddIngredient(ItemID.BreakerBlade, 5);
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
                player.statDefense += 5;
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).flyffhistoric = true; // Dryad debuff on enemy for 1 sec.
            }
        }
    }
}