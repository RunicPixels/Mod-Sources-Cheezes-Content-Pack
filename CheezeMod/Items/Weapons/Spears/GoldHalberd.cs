using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Spears
{
	public class GoldHalberd : ModItem
	{
        public override void SetDefaults()
		{

			item.damage = 13;
			item.melee = true;
            item.width = CheezeItem.defaultHalberdWidth;
            item.height = CheezeItem.defaultHalberdWidth;
            item.scale = 1.1f;
			item.maxStack = 1;

			item.autoReuse = HalberdProperties.DoOutReUse;
			item.useTime = 40;
			item.useAnimation = 40;
			item.knockBack = 5.2f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = 10000;
            item.rare = 1;
			item.shoot = mod.ProjectileType("GoldHalberd");
            item.shootSpeed = 5.3f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gold Halberd");
      Tooltip.SetDefault("Stab with LMB, Slash with RMB.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 12);
            recipe.AddRecipeGroup("CheezeMod:AnyWood", 6);
            recipe.AddTile(16);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateInventory(Player player)
        {
            if(player.altFunctionUse != 2) {
                item.useStyle = 5;
                item.shoot = mod.ProjectileType("GoldHalberd");
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
