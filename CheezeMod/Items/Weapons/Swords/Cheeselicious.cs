using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
	public class Cheeselicious : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 65;
			item.melee = true;
			item.width = 56;
			item.height = 54;


            item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 250000;
            item.scale = 1f;
			item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 12f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cheeselicious");
      Tooltip.SetDefault("It smells deliciously.\nGives Well Fed and Cheese! to the player for 5 seconds after hitting an enemy, has a chance to inflict an enemy with ichor.");
    }


        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(10) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 19);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Cheese", 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            player.AddBuff(BuffID.WellFed, 300);
            player.AddBuff(mod.BuffType("CheeseFed"), 300);
            if (Main.rand.Next(5) >= 4)
            {
                target.AddBuff(BuffID.Ichor, 300);
            }
        }
        public override bool UseItem(Player player)
        {
            if (Main.rand.Next(1500) == 0)
            {
                item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/BahSwing");
            }

            else if (Main.rand.Next(750) == 0)
            {
                item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/MooSwing");
            }
            else
            {
                item.UseSound = SoundID.Item1;
            }
            return base.UseItem(player);
        }
    }
}
