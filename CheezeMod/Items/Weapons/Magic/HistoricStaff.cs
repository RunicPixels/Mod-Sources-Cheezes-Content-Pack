using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod;

namespace CheezeMod.Items.Weapons.Magic
{
    public class HistoricStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 55; 
            item.magic = true;
            item.mana = 24;
            item.width = 42;
            item.height = 42;
            item.channel = true;

            Item.staff[item.type] = true;
            item.reuseDelay = 50;
            item.useTime = 55;
            item.useAnimation = 55;
            item.useStyle = 5;
            item.crit = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = CheezeItem.historicPrice;
            item.rare = CheezeItem.historicRarity;
            item.UseSound = SoundID.Item43;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("WindFieldCast");
            item.shootSpeed = 10f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Historic Staff");
      Tooltip.SetDefault("A staff used by the guardians of Madrigal. \nShoots a Wind Field that slows and inflics Dryad's Bane on enemies. \n+20% Max mana when hold. \n +5% critical damage and chance when hold.");
    }


        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 1f; // 1 degrees
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HistoricEssence", 5);
            recipe.AddIngredient(ItemID.AquaScepter);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.05f; // This number here changes the multiplier
                player.statManaMax2 += (int)((player.statManaMax2) * 0.2f);
            }
            HoldStats(player);
        }
        public override void HoldItem(Player player)
        {
            HoldStats(player);
        }
        public void HoldStats(Player player)
        {
            //Damage Function.
        }
    }
}
