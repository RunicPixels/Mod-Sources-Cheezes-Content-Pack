using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod.Items.Weapons.UseStyles;
using System.Collections.Generic;

namespace CheezeMod.Items.Weapons.Other
{

    public class OnePunchGlove : ModItem
	{
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.HandsOn);
            equips.Add(EquipType.HandsOff);
            return true;
        }

        private FistStyle fist;
        public FistStyle Fist
        {
            get
            {
                if (fist == null)
                {
                    fist = new FistStyle(item, 2);
                }
                return fist;
            }
        }

        public override void SetDefaults()
		{
            item.useStyle = FistStyle.useStyle;
            item.autoReuse = true;
            item.name = "One Punch Glove";
            item.melee = true;
            item.width = 34;
            item.height = 36;
            item.useTime = 90;
            item.useAnimation = 90;
            item.toolTip = "'One Punch is all you need.'";
            item.scale = 1f;
			item.damage = 3125;
            item.crit = 9;
            item.knockBack = 10f;
            item.rare = 11;
            item.value = 400000;
            item.noUseGraphic = true;
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

        public override bool AltFunctionUse(Player player)
        {
            if (player.dashDelay == 0) player.GetModPlayer<PlayerFX>(mod).weaponDash = 2;
            return player.dashDelay == 0;
        }

        public override bool UseItemFrame(Player player)
        {
            Fist.UseItemFrame(player);
            return true;
        }

        public override void UseItemHitbox(Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            // jump exactly 6 blocks high!
            noHitbox = Fist.UseItemHitbox(player, ref hitbox, 22, 27f, 0f, 750f);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            for (int i = 0; i <= 10; i++)
            {
                Dust.NewDust(target.position, target.width, target.height, mod.DustType("Sparkle"), Main.rand.NextFloat() * 4f - 2f, Main.rand.NextFloat() * 4f - 2f);
                Dust.NewDust(target.position, target.width, target.height, DustID.Fire, Main.rand.NextFloat() * 6f - 3f, Main.rand.NextFloat() * 6f - 3f);
                Dust.NewDust(target.position, target.width, target.height, DustID.Smoke, Main.rand.NextFloat() * 8f - 4f, Main.rand.NextFloat() * 8f - 4f);
                Dust.NewDust(target.position, target.width, target.height, 267 , Main.rand.NextFloat() * 8f - 4f, Main.rand.NextFloat() * 8f - 4f);
            }
            target.AddBuff(BuffID.Confused, 600);
            target.netUpdate = true;

            int combo = Fist.OnHitNPC(player, target, true);
            if (combo != -1)
            {
                Main.PlaySound(4, (int)target.position.X, (int)target.position.Y, 14);
            }
        }



        public override bool UseItem(Player player)
        {
            if (player.velocity.X >= -25 && player.velocity.X <= 25 && player.altFunctionUse == 2)
            {
                player.velocity.X += player.direction;
            }
            return base.UseItem(player);
        }
    }
}