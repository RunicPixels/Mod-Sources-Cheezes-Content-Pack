using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class MegaGoldWalloper : ModItem
	{
		public override void SetDefaults()
		{
            item.useStyle = 3;
            item.autoReuse = false;

            item.width = 42;
            item.height = 42;
            item.useTime = 60;
            item.useAnimation = item.useTime;
            item.melee = true;


            item.scale = 0.8f;
			item.damage = 145;
            item.knockBack = 9f;
            item.rare = CheezeItem.ratchetRarity[2];
            item.value = 300000;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mega Gold Walloper");
      Tooltip.SetDefault("'Fits like a golden glove and hits like a golden truck which inflicts Midas and Confusion'\nInspired by Ratchet and Clank.");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GoldWalloper");
            recipe.AddIngredient(null, "HallowedBolt", 50);
            recipe.AddIngredient(ItemID.GoldDust, 10);
            recipe.AddIngredient(ItemID.LightShard);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Confused, 60);
            target.AddBuff(BuffID.Midas, 180);
            player.AddBuff(BuffID.ShadowDodge, 13);
        }
        public override bool UseItem(Player player)
        {
            player.velocity.Y *= 0.5f;
            if (player.velocity.X >= -10 && player.velocity.X <= 10)
            {
                player.velocity.X += player.direction;
            }
            return base.UseItem(player);
        }
    }
}
