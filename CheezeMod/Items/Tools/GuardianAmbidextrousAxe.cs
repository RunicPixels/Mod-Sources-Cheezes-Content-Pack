using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Tools
{
	public class GuardianAmbidextrousAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Guardian Ambidextrous Axe";
			item.damage = 51;
			item.melee = true;
            item.width = 68;
			item.height = 58;
			item.toolTip = "An enourmous axe used by the guardians of Madrigal. \n+6% Critical Chance. \n+10 HP when holding. \n+4 Defense when holding.";
            item.crit = 6;
            item.scale = 1.1f;
            item.useTime = 64;
			item.useAnimation = 64;
			item.axe = 35;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = CheezeItem.guardianPrice;
			item.rare = CheezeItem.guardianRarity;
			item.useSound = 1;
			item.autoReuse = false;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddRecipeGroup("CheezeMod:EvilAxes");
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
                player.statLifeMax2 += 10;
                player.statDefense += 4;
            }
        }
    }
}