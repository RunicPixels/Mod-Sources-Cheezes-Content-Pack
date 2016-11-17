using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Other
{
    public class GuardianKnuckle : ModItem
    {
        public float speedModifier = 4.5f;
        public int maxSpeed = 20;
        public override void SetDefaults()
        {
            item.useStyle = 3;
            item.autoReuse = true;
            item.name = "Guardian Knuckle";
            item.width = 30;
            item.height = 30;
            item.melee = true;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.toolTip = "An knuckle used by the guardians of Madrigal.\nOne step forward and one step back.\n+6% Critical Chance. \n+23% Increased Critical Damage. \nGives dodge frames upon hitting an enemy.";
            item.crit = 6;
            item.scale = 1.1f;
            item.damage = 33;
            item.knockBack = 5.5f;
            item.rare = 2;
            item.value = 25000;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddIngredient(ItemID.CopperShortsword);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if(Main.rand.Next(5) == 0)
            {
                target.AddBuff(BuffID.Confused, 300);
            }
            else
            {
                target.AddBuff(BuffID.Confused, 30);
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
                player.velocity.X *= 0.01f;
                player.AddBuff(BuffID.ShadowDodge, 2);
            }
            if (player.itemAnimation == player.itemAnimationMax - 3)
            {
                player.AddBuff(BuffID.ShadowDodge, 3);
            }
            if (player.itemAnimation == player.itemAnimationMax / 2)
            {
                player.velocity.X *= 0.02f;
            }
            return base.UseItem(player);
        }
        public override void UpdateInventory(Player player)
        {
            base.UpdateInventory(player);
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.23f; // This number here changes the multiplier
            }
        }
    }
}