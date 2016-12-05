using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Tools
{
	public class HistoricAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Historic Axe";
			item.damage = 47;
			item.melee = true;
			item.width = 34;
			item.height = 32;
			item.toolTip = "An axe that is an historic artifact of Madrigal. \n+17% Critical Chance. \n+7% Increased Critical Damage. \n+15 Max health when holding. \n Inflics Dryad's Bane on enemy hit.";
            item.crit = 17;
            item.scale = 1.0f;
            item.useTime = 29;
			item.useAnimation = 29;
			item.axe = 25;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = CheezeItem.historicPrice;
			item.rare = CheezeItem.historicRarity;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HistoricEssence", 5);
            recipe.AddIngredient(null, "PearlwoodAxe");
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
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.15f; // This number here changes the multiplier
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).flyffhistoric = true; // Dryad debuff on enemy for 1 sec.
                player.statLifeMax2 += 15;
            }
        }
    }
}