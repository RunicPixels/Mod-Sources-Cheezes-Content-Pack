using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Magic
{
    public class GuardianWand : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Guardian Wand";
            item.damage = 30;
            item.magic = true;
            item.mana = 6;
            item.width = 42;
            item.height = 42;
            item.channel = true;
            item.toolTip = "An wand used by the guardians of Madrigal. \nShoots a penetrating Psychic Bomb that inflics ShadowFlame. \n+15 Max mana when hold. \n +12% critical damage when hold.";
            Item.staff[item.type] = true;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.channel = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = CheezeItem.guardianPrice;
            item.rare = CheezeItem.guardianRarity;
            item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/PsyBomb");
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("PsychicBomb");
            item.shootSpeed = 7f;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 0.5f * 0.0174f; // 0.5 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
            speedX = baseSpeed * (float)Math.Sin(randomAngle);
            speedY = baseSpeed * (float)Math.Cos(randomAngle);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddIngredient(ItemID.WandofSparking);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.12f; // This number here changes the multiplier
                player.statManaMax2 += 15;

            }
            HoldStats(player);
        }
        public override void HoldItem(Player player)
        {
            HoldStats(player);
        }
        public void HoldStats(Player player)
        {
            // Equal to functions.
        }
    }
}