using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Sticks
{
	public class GuardianStick : ModItem
	{
        public override void SetDefaults()
		{
			item.name = "Guardian Stick";
			item.damage = 20;
			item.melee = true;
            item.width = 42;
            item.height = 42;
            item.scale = 1f;
			item.maxStack = 1;
			item.toolTip = "An stick used by the guardians of Madrigal. \nSlash with LMB, Heal 10hp with RMB, costs 50 mana.";
			item.useTime = 38;
			item.useAnimation = 38;
			item.knockBack = 5.2f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
            item.noUseGraphic = false;
            item.autoReuse = false;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = CheezeItem.guardianPrice;
            item.rare = CheezeItem.guardianRarity;
            item.shootSpeed = 4f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddIngredient(ItemID.LesserHealingPotion, 10);
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
                player.statLife += 10;
                player.HealEffect(10);
            }
            return base.UseItem(player);
        }
    }
}