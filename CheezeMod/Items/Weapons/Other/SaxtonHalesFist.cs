using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Other
{
	public class SaxtonHalesFist : ModItem
	{
        int braveJumpTimer = 0;
		public override void SetDefaults()
		{
            item.useStyle = 3;
            item.autoReuse = false;
            item.name = "Saxton Hale's Fist";
            item.melee = true;
            item.width = 34;
            item.height = 36;
            item.useTime = 50;
            item.useAnimation = item.useTime;
            item.toolTip = "'It's just you, me and my bare hands.' Inspired by Saxton Hale from TF2.";
            item.toolTip2 = "Do a Brave Jump with your RMB.";
            item.scale = 0.8f;
			item.damage = 195;
            item.crit = 20;
            item.knockBack = 8f;
            item.useSound = 1;
            item.rare = 7;
            item.value = 400000;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(null, "Cheese");
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            for(int i = 0;i<=10;i++)
            { 
            Dust.NewDust(target.position, target.width, target.height, DustID.Blood, Main.rand.NextFloat() * 8f - 4f, Main.rand.NextFloat() * 8f - 4f);
            }
            player.AddBuff(BuffID.ShadowDodge, 12);
            target.AddBuff(BuffID.Confused, 600);
            Main.PlaySound(4, (int)target.position.X, (int)target.position.Y, 14);
        }
        public override void UpdateInventory(Player player)
        {
            if (braveJumpTimer <= 0) { braveJumpTimer++; }
            if (braveJumpTimer == 0) { Main.PlaySound(25, player.position); }
        }
        public override bool UseItem(Player player)
        {
            if (player.velocity.X >= -7 && player.velocity.X <= 7)
            {
                player.velocity.X += player.direction * 0.5f;
                
            }
            item.useSound = 1;
            return base.UseItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {
            if (braveJumpTimer >= 0)
            {
                if (Main.rand.Next(4) == 0)
                {
                    item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/SaxtonHaleJump01");
                }
                else if (Main.rand.Next(3) == 0)
                {
                    item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/SaxtonHaleJump02");
                }
                else if (Main.rand.Next(2) == 0)
                {
                    item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/SaxtonHaleJump03");
                }
                else
                {
                    item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/SaxtonHaleJump04");
                }
                player.position.Y -= 1.5f;
                player.velocity.Y = -15f;
                player.velocity.Y -= 7.5f;
                player.justJumped = true;
                braveJumpTimer = -360;
                return true;
            }
            return false;
            
        }
    }
}