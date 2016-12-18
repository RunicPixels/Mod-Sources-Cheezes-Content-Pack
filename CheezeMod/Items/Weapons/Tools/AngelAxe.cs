using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Tools
{
	public class AngelAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Angel Axe";
			item.damage = 80;
			item.melee = true;
			item.width = 52;
			item.height = 52;
			item.toolTip = "An axe that once used by the angels of Madrigal. \n+19% Critical Chance. \n+12% Increased Critical Damage. \n+18 Max health when holding. \n Inflics Dryad's Bane on enemy hit.";
            item.crit = 19;
            item.scale = 1f;
            item.useTime = 28;
			item.useAnimation = 28;
			item.axe = 30;
			item.useStyle = 1;
			item.knockBack = 6.1f;
			item.value = CheezeItem.historicPrice;
			item.rare = CheezeItem.historicRarity;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AngelEssence", 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.MythrilAnvil);
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
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.12f; // This number here changes the multiplier
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).flyffangelic = true; // Dryad debuff on enemy for 1 sec.
                player.statLifeMax2 += 18;
            }
        }
    }
}