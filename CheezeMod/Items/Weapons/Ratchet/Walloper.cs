using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class Walloper : ModItem
	{
		public override void SetDefaults()
		{
            item.useStyle = 3;
            item.autoReuse = false;
			item.name = "Walloper";
            item.width = 42;
            item.height = 42;
            item.melee = true;
            item.useTime = 70;
            item.useAnimation = item.useTime;
            item.toolTip = "'Fits like a glove and hits like a truck.'";
            item.toolTip2 = "Originally from Ratchet and Clank.";
            item.scale = 0.8f;
			item.damage = 21;
            item.knockBack = 6.5f;
            item.rare = 1;
            item.value = 2000;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IronBolt", 50);
            recipe.AddIngredient(ItemID.StoneBlock, 30);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Confused, 30);
            player.AddBuff(BuffID.ShadowDodge, 13);
        }
        public override bool UseItem(Player player)
        {
            player.velocity.Y *= 0.9f;
            if (player.velocity.X >= -6 && player.velocity.X <= 6) {
                
                player.velocity.X += player.direction;
            }
            return base.UseItem(player);
        }
    }
}