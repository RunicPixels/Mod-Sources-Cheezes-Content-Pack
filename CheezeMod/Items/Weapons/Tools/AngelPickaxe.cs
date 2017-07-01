using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Tools
{
	public class AngelPickaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 48;
			item.melee = true;
            item.width = 52;
			item.height = 50;

            item.crit = 5;
            item.scale = 1.0f;
            item.useTime = 15;
			item.useAnimation = 15;
            item.pick = 205;
            item.tileBoost = 1;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = CheezeItem.angelPrice;
			item.rare = CheezeItem.angelRarity;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Angel Pickaxe");
      Tooltip.SetDefault("A pickaxe that once used by the angels of Madrigal. \n+5% Critical Chance. \n+22% Increased Critical Damage. \n+20 Max health when holding. \nInflics Angels's Bane on enemy hit.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AngelEssence", 5);
            recipe.AddIngredient(ItemID.Drax);
            recipe.AddTile(TileID.MythrilAnvil);
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
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.22f; // This number here changes the multiplier
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).flyffangelic = true; // Dryad debuff on enemy for 1 sec.
                player.statLifeMax2 += 29;
            }
        }
    }
}
