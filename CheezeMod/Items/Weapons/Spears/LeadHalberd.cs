using System;
using Microsoft.Xna.Framework;
using CheezeMod;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Spears
{
	public class LeadHalberd : ModItem
	{
        public override void SetDefaults()
		{

			item.damage = 10;
			item.melee = true;
			item.width = CheezeItem.defaultHalberdWidth;
			item.height = CheezeItem.defaultHalberdWidth;
			item.scale = 1.1f;
			item.maxStack = 1;
			item.autoReuse = HalberdProperties.DoOutReUse;
			item.useTime = 45;
			item.useAnimation = 45;
			item.knockBack = 4.6f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = 10000;
            item.rare = 1;
			item.shoot = mod.ProjectileType("LeadHalberd");
            item.shootSpeed = 4.4f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Lead Halberd");
      Tooltip.SetDefault("Stab with LMB, Slash with RMB.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadBar, 12);
            recipe.AddRecipeGroup("CheezeMod:AnyWood", 6);
            recipe.AddTile(16);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateInventory(Player player)
        {
            if(player.altFunctionUse != 2) {
                item.useStyle = 5;
                item.shoot = mod.ProjectileType("LeadHalberd");
                item.noMelee = true;
                item.noUseGraphic = true;
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            if (player.itemAnimation == 0)
            {
                item.useStyle = 1;
                item.shoot = 0;
                item.noMelee = false;
                item.noUseGraphic = false;
                return true;
            }
            return false;
        }
    }
}
