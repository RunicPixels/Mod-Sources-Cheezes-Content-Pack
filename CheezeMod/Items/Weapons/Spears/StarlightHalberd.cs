using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Spears
{
	public class StarlightHalberd : ModItem
	{
        public override void SetDefaults()
		{

			item.damage = 18;
			item.melee = true;
            item.width = CheezeItem.defaultHalberdWidth;
            item.height = CheezeItem.defaultHalberdWidth;
            item.scale = 1.1f;
			item.maxStack = 1;

			item.useTime = 38;
			item.useAnimation = 38;
			item.knockBack = 5.2f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = 10000;
            item.rare = 2;
			item.shoot = mod.ProjectileType("StarlightHalberd");
            item.shootSpeed = 5.3f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Starlight Halberd");
      Tooltip.SetDefault("Stab with LMB, Slash with RMB.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StarlightBar", 12);
            recipe.AddRecipeGroup("CheezeMod:AnyWood", 6);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(16);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateInventory(Player player)
        {
            if(player.altFunctionUse != 2) {
                item.useStyle = 5;
                item.shoot = mod.ProjectileType("StarlightHalberd");
                item.noMelee = true;
                item.noUseGraphic = true;
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            Projectile.NewProjectile(player.Center.X, player.Center.Y - 300f, Main.rand.NextFloat() * 4f - 2f, Main.rand.NextFloat() * 3 + 6f, mod.ProjectileType("StarStorm2"), item.damage, item.knockBack * 0.85f, item.owner, 0f, 0f);
            Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 25);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("ShortSparkle"));
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
