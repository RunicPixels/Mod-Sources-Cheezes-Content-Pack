using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Spears
{
	public class SkullHalberd : ModItem
	{
        public override void SetDefaults()
		{
			item.name = "Skull Halberd";
			item.damage = 23;
			item.melee = true;
            item.width = CheezeItem.defaultHalberdWidth;
            item.height = CheezeItem.defaultHalberdWidth;
            item.scale = 1.1f;
			item.maxStack = 1;
			item.toolTip = "Stab with LMB, Slash with RMB.";
			item.useTime = 34;
			item.useAnimation = 34;
			item.knockBack = 5.5f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = 10000;
            item.rare = 4;
			item.shoot = mod.ProjectileType("SkullHalberd");
            item.shootSpeed = 5.15f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 30);
            recipe.AddRecipeGroup("CheezeMod:AnyWood", 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(6) == 0)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y - 300f, Main.rand.NextFloat() * 4f - 2f, Main.rand.NextFloat() * 3 + 6f, ProjectileID.Skull, item.damage, item.knockBack * 0.85f, item.owner, 0f, 0f);
            }  
        }
        public override void UpdateInventory(Player player)
        {
            if(player.altFunctionUse != 2) {
                item.useStyle = 5;
                item.shoot = mod.ProjectileType("SkullHalberd");
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