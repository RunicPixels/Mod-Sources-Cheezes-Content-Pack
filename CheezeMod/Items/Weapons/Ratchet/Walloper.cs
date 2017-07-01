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

            item.width = 42;
            item.height = 42;
            item.melee = true;
            item.useTime = 63;
            item.useAnimation = item.useTime;


            item.scale = 0.8f;
			item.damage = 21;
            item.knockBack = 6.5f;
            item.rare = CheezeItem.ratchetRarity[0];
            item.value = 8000;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Walloper");
      Tooltip.SetDefault("'Fits like a glove and hits like a truck.'\nOriginally from Ratchet and Clank.");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IronBolt", 50);
            recipe.AddIngredient(ItemID.ClimbingClaws);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Confused, 20);
            player.AddBuff(BuffID.ShadowDodge, 10);
        }
        public override bool UseItem(Player player)
        {
            player.velocity.Y *= 0.91f;
            if (player.velocity.X >= -6 && player.velocity.X <= 6) {
                
                player.velocity.X += player.direction;
            }
            return base.UseItem(player);
        }
    }
}
