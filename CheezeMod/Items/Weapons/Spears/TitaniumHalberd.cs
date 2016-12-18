using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Spears
{
	public class TitaniumHalberd : ModItem
	{
        public override void SetDefaults()
		{
			item.name = "Titanium Halberd";
			item.damage = 49;
			item.melee = true;
            item.width = CheezeItem.defaultHalberdWidth;
            item.height = CheezeItem.defaultHalberdWidth;
            item.scale = 1.1f;
			item.maxStack = 1;
			item.toolTip = "Stab with LMB, Slash with RMB.";
			item.useTime = 29;
			item.useAnimation = 29;
			item.knockBack = 5.3f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = 30000;
            item.rare = 4;
			item.shoot = mod.ProjectileType("TitaniumHalberd");
            item.shootSpeed = 7.05f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 12);
            recipe.AddRecipeGroup("CheezeMod:AnyWood", 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateInventory(Player player)
        {
            if(player.altFunctionUse != 2) {
                item.useStyle = 5;
                item.shoot = mod.ProjectileType("TitaniumHalberd");
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