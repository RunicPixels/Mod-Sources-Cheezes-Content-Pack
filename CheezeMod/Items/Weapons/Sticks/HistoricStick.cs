using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Sticks
{
	public class HistoricStick : ModItem
	{
        public override void SetDefaults()
		{

			item.damage = 40;
			item.melee = true;
            item.width = 42;
            item.height = 42;
            item.scale = 1f;
			item.maxStack = 1;

			item.useTime = 36;
			item.useAnimation = 36;
            item.autoReuse = false;
			item.knockBack = 5.2f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
            item.noUseGraphic = false;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = CheezeItem.historicPrice;
            item.rare = CheezeItem.historicRarity;
            item.shootSpeed = 4f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Historic Stick");
      Tooltip.SetDefault("A stick used by the guardians of Madrigal. \nSlash with LMB, Heal 15hp with RMB, costs 60 mana. \n +20 mana when held. \n Inflicts Dryad's Bane on enemies hit. and Dryad's Blessing when healing.");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HistoricEssence", 5);
            recipe.AddIngredient(ItemID.HealingPotion, 10);
            recipe.AddTile(18);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void UpdateInventory(Player player)
        {
            if(player.altFunctionUse != 2) {
                item.useStyle = 1;
                item.shoot = 0;
                item.mana = 0;
                item.UseSound = SoundID.Item1;
                item.noMelee = false;
                item.noUseGraphic = false;
                item.autoReuse = true;
            }
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).flyffhistoric = true; // Dryad debuff on enemy for 1 sec.
                player.statManaMax2 += 20;
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            if (player.itemAnimation == 0)
            {
                item.noMelee = true;
                item.useStyle = 5;
                item.mana = 50;
                item.UseSound = SoundID.Item9;
                return true;
            }
            return false;
        }
        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2 && player.itemAnimation == 5)
            {
                player.statLife += 15;
                player.HealEffect(15);
                player.AddBuff(BuffID.DryadsWard, 60);
            }
            return base.UseItem(player);
        }
    }
}
