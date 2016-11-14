using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class GoldWalloper : ModItem
	{
		public override void SetDefaults()
		{
            item.useStyle = 3;
            item.autoReuse = false;
            item.name = "Gold Walloper";
            item.width = 42;
            item.height = 42;
            item.useTime = 45;
            item.melee = true;
            item.useAnimation = item.useTime;
            item.toolTip = "'Fits like a golden glove and hits like a golden truck.'";
            item.toolTip2 = "Originally from Ratchet and Clank.";
            item.scale = 0.8f;
			item.damage = 62;
            item.knockBack = 8f;
            item.rare = 4;
            item.value = 20000;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Walloper");
            recipe.AddIngredient(null, "HellstoneBolt", 50);
            recipe.AddRecipeGroup("CheezeMod:GoldBars", 5);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Confused, 36);
            player.AddBuff(BuffID.ShadowDodge, 13);
        }
        public override bool UseItem(Player player)
        {
            player.velocity.Y *= 0.75f;
            if (player.velocity.X >= -8 && player.velocity.X <= 8)
            {
                player.velocity.X += player.direction;
            }
            return base.UseItem(player);
        }
    }
}