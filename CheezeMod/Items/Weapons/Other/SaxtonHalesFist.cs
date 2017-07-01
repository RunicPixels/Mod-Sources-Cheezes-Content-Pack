using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod.Items.Weapons.UseStyles;
using System.Collections.Generic;

namespace CheezeMod.Items.Weapons.Other
{
    [AutoloadEquip((EquipType.HandsOn), (EquipType.HandsOff))]
    public class SaxtonHalesFist : ModItem
	{
        private FistStyle fist;
        public FistStyle Fist
        {
            get
            {
                if (fist == null)
                {
                    fist = new FistStyle(item, 10);
                }
                return fist;
            }
        }

        int braveJumpTimer = 0;
		public override void SetDefaults()
		{
            item.useStyle = FistStyle.useStyle;
            item.autoReuse = true;

            item.melee = true;
            item.width = 34;
            item.height = 36;
            item.useTime = 50;
            item.useAnimation = item.useTime;


            item.scale = 0.8f;
			item.damage = 195;
            item.noUseGraphic = true;
            item.crit = 10;
            item.knockBack = 8f;
            item.UseSound = SoundID.Item1;
            item.rare = 7;
            item.value = 400000;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Saxton Hale's Fist");
      Tooltip.SetDefault("'It's just you, me and my bare hands.' Inspired by Saxton Hale from TF2.\nDo a Brave Jump with your Right Mouse Button.");
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
            target.AddBuff(BuffID.Confused, 600);
            target.AddBuff(BuffID.Midas, 120);
            Main.PlaySound(4, (int)target.position.X, (int)target.position.Y, 14);
        }
        public override void UpdateInventory(Player player)
        {
            if (braveJumpTimer <= 0) { braveJumpTimer++; }
            if (braveJumpTimer == 0) { Main.PlaySound(25, player.position); }
            if (player.inventory[player.selectedItem] == this.item)
            {
                player.noFallDmg = true;
                player.maxFallSpeed += 5f;
            }
        }
        public override bool UseItem(Player player)
        {
            item.UseSound = SoundID.Item1;
            return base.UseItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {
            if (braveJumpTimer >= 0)
            {
                if (Main.rand.Next(4) == 0)
                {
                    item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SaxtonHaleJump01");
                }
                else if (Main.rand.Next(3) == 0)
                {
                    item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SaxtonHaleJump02");
                }
                else if (Main.rand.Next(2) == 0)
                {
                    item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SaxtonHaleJump03");
                }
                else
                {
                    item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SaxtonHaleJump04");
                }
                player.position.Y -= 1.5f;
                player.velocity.Y = -16f;
                player.velocity.Y -= 7.7f;
                player.justJumped = true;
                braveJumpTimer = -360;
                if (player.dashDelay == 0) player.GetModPlayer<PlayerFX>(mod).weaponDash = 10;
                return player.dashDelay == 0;
 
            }
            return false;
        }

        public override bool UseItemFrame(Player player)
        {
            Fist.UseItemFrame(player);
            return true;
        }
        public override void UseItemHitbox(Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            // jump exactly 6 blocks high!
            noHitbox = Fist.UseItemHitbox(player, ref hitbox, 22, 9f, 7f, 12f);
        }
    }
}
