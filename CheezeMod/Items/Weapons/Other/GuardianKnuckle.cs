using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod.Items.Weapons.UseStyles;
using System.Collections.Generic;

namespace CheezeMod.Items.Weapons.Other
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class GuardianKnuckle : ModItem
    {
        private FistStyle fist;
        public FistStyle Fist
        {
            get
            {
                if (fist == null)
                {
                    fist = new FistStyle(item, 4);
                }
                return fist;
            }
        }

        public override void SetDefaults()
        {
            item.useStyle = FistStyle.useStyle;
            item.autoReuse = true;

            item.width = 30;
            item.height = 30;
            item.melee = true;
            item.useAnimation = 28;

            item.crit = 6;
            item.noUseGraphic = true;
            item.scale = 1.1f;
            item.damage = 33;
            item.UseSound = SoundID.Item7;
            item.knockBack = 5.5f;
            item.rare = CheezeItem.guardianRarity;
            item.value = CheezeItem.guardianPrice;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Guardian Knuckle");
      Tooltip.SetDefault("A knuckle used by the guardians of Madrigal.\n Right Click to do a Burst Crack.\n+6% Critical Chance. \n+10% Increased Critical Damage. \nGives dodge frames upon hitting an enemy.");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddIngredient(ItemID.Leather, 3);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool AltFunctionUse(Player player)
        {
            if (player.dashDelay == 0) player.GetModPlayer<PlayerFX>(mod).weaponDash = 1;
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
            noHitbox = Fist.UseItemHitbox(player, ref hitbox, 22, 9f, 7f, 12f);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            int combo = Fist.OnHitNPC(player, target, true);
            if (combo != -1)
            {
                if (combo % Fist.punchComboMax == 0)
                {
                    //maybe confuse
                    target.AddBuff(BuffID.Confused, 30 * Main.rand.Next(1, 4), false);
                }
            }
        }
        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.10f; // This number here changes the multiplier
            }
        }
    }
}
