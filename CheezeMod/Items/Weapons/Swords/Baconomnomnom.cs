using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
	public class Baconomnomnom : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Baconomnomnom";
			item.damage = 62;
			item.melee = true;
			item.width = 56;
			item.height = 58;
			item.toolTip = "It slashes deliciously.";
            item.toolTip2 = "Gives Well Fed and Rapid Healing to the player for 5 seconds after hitting an enemy, has a chance to inflict an enemy with ichor.";
            item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 250000;
            item.scale = 1f;
			item.rare = 6;
            item.UseSound = SoundID.Item59;
			item.autoReuse = true;
            item.shootSpeed = 12f;
		}

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(50) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 117);
            }
            if (Main.rand.Next(50) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 125);
            }
            if (Main.rand.Next(20) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 19);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bacon, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            player.AddBuff(BuffID.WellFed, 300);
            player.AddBuff(BuffID.RapidHealing, 300);
            if (Main.rand.Next(5) >= 4)
            {
                target.AddBuff(BuffID.Ichor, 300);
            }
        }
    }
}