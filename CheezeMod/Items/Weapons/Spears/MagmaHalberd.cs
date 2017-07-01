using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Spears
{
	public class MagmaHalberd : ModItem
	{
        public override void SetDefaults()
		{

			item.damage = 31;
			item.melee = true;
			item.width = 48;
			item.height = 50;
			item.scale = 1.2f;
			item.maxStack = 1;

			item.useTime = 45;
			item.useAnimation = 45;
			item.knockBack = 5.2f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 5;
            item.value = 20000;
            item.rare = 3;
			item.shoot = mod.ProjectileType("MagmaHalberd");
            item.shootSpeed = 4.5f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Magma Halberd");
      Tooltip.SetDefault("Stab with LMB, Slash with RMB. It will ignite your enemies.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(ItemID.Obsidian, 12);
            recipe.AddTile(16);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateInventory(Player player)
        {
            if(player.altFunctionUse != 2) {
                item.useStyle = 5;
                item.shoot = mod.ProjectileType("MagmaHalberd");
                item.noMelee = true;
                item.noUseGraphic = true;
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(new Vector2(hitbox.X, hitbox.Y), 0.5f, 0.3f, 0.0f);
            if (Main.rand.Next(2) == 0)
            {

                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
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
