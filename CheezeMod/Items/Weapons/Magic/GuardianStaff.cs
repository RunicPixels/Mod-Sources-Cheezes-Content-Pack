using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Magic
{
    public class GuardianStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 40;
            item.magic = true;
            item.mana = 13;
            item.width = 42;
            item.height = 42;
            item.channel = true;

            Item.staff[item.type] = true;
            item.useTime = 46;
            item.useAnimation = 46;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = CheezeItem.guardianPrice;
            item.rare = CheezeItem.guardianRarity;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Fire");
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("FlameGeyser");
            item.shootSpeed = 12f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Guardian Staff");
      Tooltip.SetDefault("A staff used by the guardians of Madrigal. \nShoots a flame geyser. \n+20 Max mana when hold. \n +6% critical damage when hold.");
    }


        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 3f; // 3 degrees
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.X);
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.Y);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddIngredient(ItemID.AmberStaff);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.06f; // This number here changes the multiplier
                player.statManaMax2 += 20;
            }
        }
    }
}
