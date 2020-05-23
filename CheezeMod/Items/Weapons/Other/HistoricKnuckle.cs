using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using CheezeMod.Items.Weapons.UseStyles;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace CheezeMod.Items.Weapons.Other
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class HistoricKnuckle : ModItem
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

        public float speedModifier = 8.5f;
        public int maxSpeed = 50;
        public override void SetDefaults()
        {
            item.useStyle = FistStyle.useStyle;
            item.autoReuse = true;

            item.width = 30;
            item.height = 30;
            item.melee = true;
            item.useTime = 26;
            item.useAnimation = 24;
            item.noUseGraphic = true;

            item.crit = 7;
            item.scale = 1.1f;
            item.UseSound = SoundID.Item7;
            item.damage = 48;
            item.knockBack = 6f;
            item.rare = CheezeItem.historicRarity;
            item.value = CheezeItem.historicPrice;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Historic Knuckle");
      Tooltip.SetDefault("A knuckle that is an historic artifact of Madrigal.\nOne step forward and one step back.\n+7% Critical Chance. \n+25% Increased Critical Damage. \n Gives dodge frames to the player and inflict dryad's bane on the enemy upon hitting an enemy.");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HistoricEssence", 5);
            recipe.AddIngredient(ItemID.Pwnhammer);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            int combo = Fist.OnHitNPC(player, target, true);
            if (combo != -1)
            {
                if (combo % Fist.punchComboMax == 0)
                {
                    //maybe confuse and shadow dryads ward
                    target.AddBuff(BuffID.Confused, 40 * Main.rand.Next(1, 4), false);
                    target.AddBuff(BuffID.DryadsWardDebuff, 60 * Main.rand.Next(1, 4));
                }
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            if (player.dashDelay == 0) player.GetModPlayer<PlayerFX>().weaponDash = 1;
            return player.dashDelay == 0;
        }

        public override bool UseItemFrame(Player player)
        {
            Fist.UseItemFrame(player);
            return true;
        }
        public override void UseItemHitbox(Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            // jump exactly 9 blocks high!
            noHitbox = Fist.UseItemHitbox(player, ref hitbox, 22, 12f, 7f, 14f);
        }
        public override void UpdateInventory(Player player)
        {
            base.UpdateInventory(player);
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.25f; // This number here changes the multiplier
            }
        }
    }
}
