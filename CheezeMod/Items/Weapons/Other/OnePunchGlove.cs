using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Other
{
	public class OnePunchGlove : ModItem
	{
		public override void SetDefaults()
		{
            item.useStyle = 3;
            item.autoReuse = false;
            item.name = "One Punch Glove";
            item.melee = true;
            item.width = 34;
            item.height = 36;
            item.useTime = 100;
            item.useAnimation = item.useTime;
            item.toolTip = "'One Punch is all you need.'";
            item.scale = 0.8f;
			item.damage = 2500;
            item.crit = 6;
            item.knockBack = 20f;
            item.rare = 11;
            item.value = 400000;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            for(int i = 0;i<=10;i++)
            { 
            Dust.NewDust(target.position, target.width, target.height, mod.DustType("Sparkle"), Main.rand.NextFloat() * 4f - 2f, Main.rand.NextFloat() * 4f - 2f);
            Dust.NewDust(target.position, target.width, target.height, DustID.GoldCoin, Main.rand.NextFloat() * 6f - 3f, Main.rand.NextFloat() * 6f - 3f);
            Dust.NewDust(target.position, target.width, target.height, DustID.RainbowMk2, Main.rand.NextFloat() * 8f - 4f, Main.rand.NextFloat() * 8f - 4f);
            Dust.NewDust(target.position, target.width, target.height, DustID.Blood, Main.rand.NextFloat() * 8f - 4f, Main.rand.NextFloat() * 8f - 4f);
            }
            target.AddBuff(BuffID.Confused, 600);
            player.AddBuff(BuffID.ShadowDodge, 15);
            Main.PlaySound(4, (int)target.position.X, (int)target.position.Y, 14);
        }
        public override bool UseItem(Player player)
        {
            player.velocity.Y *= 0.01f;
            if (player.velocity.X >= -25 && player.velocity.X <= 25)
            {
                player.velocity.X += player.direction;
                
            }
            return base.UseItem(player);
        }
    }
}