using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Tools
{
	public class HistoricPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Historic Pickaxe";
			item.damage = 28;
			item.melee = true;
			item.width = 34;
			item.height = 30;
			item.toolTip = "An pickaxe that is an historic artifact of Madrigal. \n+6% Critical Chance. \n+20% Increased Critical Damage. \n+15 Max health when holding. \nInflics Dryad's Bane on enemy hit.";
            item.crit = 6;
            item.scale = 1.0f;
            item.useTime = 20;
			item.useAnimation = 20;
            item.pick = 110;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = CheezeItem.historicPrice;
			item.rare = CheezeItem.historicRarity;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HistoricEssence", 5);
            recipe.AddIngredient(ItemID.PearlwoodSword);
            recipe.AddTile(18);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(20) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 29);
			}
		}

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.2f; // This number here changes the multiplier
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).flyffhistoric = true; // Dryad debuff on enemy for 1 sec.
                player.statLifeMax2 += 15;
            }
        }
    }
}