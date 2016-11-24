using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Other
{
    public class HistoricKnuckle : ModItem
    {
        public float speedModifier = 8.5f;
        public int maxSpeed = 50;
        public override void SetDefaults()
        {
            item.useStyle = 3;
            item.autoReuse = true;
            item.name = "Historic Knuckle";
            item.width = 30;
            item.height = 30;
            item.melee = true;
            item.useTime = 26;
            item.useAnimation = item.useTime;
            item.toolTip = "An knuckle that is an historic artifact of Madrigal.\nOne step forward and one step back.\n+7% Critical Chance. \n+25% Increased Critical Damage. \n Gives dodge frames to the player and inflict dryad's bane on the enemy upon hitting an enemy.";
            item.crit = 7;
            item.scale = 1.1f;
            item.damage = 48;
            item.knockBack = 6f;
            item.rare = CheezeItem.historicRarity;
            item.value = CheezeItem.historicPrice;
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
            if(Main.rand.Next(5) == 0)
            {
                target.AddBuff(BuffID.Confused, 300);
                target.AddBuff(BuffID.DryadsWardDebuff, 300);

            }
            else
            {
                target.AddBuff(BuffID.Confused, 30);
                target.AddBuff(BuffID.DryadsWardDebuff, 60);
            }
            player.AddBuff(BuffID.ShadowDodge, 5);
        }
        public override bool UseItem(Player player)
        {
            player.velocity.Y *= 0.98f;
            if (player.velocity.X >= -maxSpeed && player.velocity.X <= maxSpeed && player.itemAnimation < player.itemAnimationMax / 4)
            {
                if (player.direction > 0)
                {
                    player.velocity.X -= speedModifier;
                }
                else
                {
                    player.velocity.X += speedModifier;
                }
            }
            if (player.velocity.X >= -maxSpeed && player.velocity.X <= maxSpeed && player.itemAnimation > player.itemAnimationMax / 2 && player.itemAnimation < player.itemAnimationMax / 4 * 3)
            {
                if (player.direction < 0)
                {
                    player.velocity.X -= speedModifier;
                }
                else
                {
                    player.velocity.X += speedModifier;
                }
            }
            if (player.itemAnimation <= 1)
            {
                player.velocity.X *= 0.001f;
                player.AddBuff(BuffID.ShadowDodge, 2);
            }
            if (player.itemAnimation == player.itemAnimationMax - 3)
            {
                player.AddBuff(BuffID.ShadowDodge, 3);
            }
            if (player.itemAnimation == player.itemAnimationMax / 2)
            {
                player.velocity.X *= 0.002f;
            }
            return base.UseItem(player);
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