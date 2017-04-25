using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
	public class SwordOfTheSilverSword : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.StarWrath);
			item.name = "Sword of the Silver Sword";
            item.toolTip = "That's a lot of sword.";
            item.useTime = 48;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.width = 58;
            item.height = 60;
            item.rare = 1;
            item.autoReuse = true;
            item.useAnimation = 25;
            item.damage = 15;
            item.knockBack = 3;
            item.value = 8250;
            item.autoReuse = true;
            item.scale = 0.75f;
            item.shoot = 0;
        }


        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if(player.itemAnimation % (item.useAnimation / 4) == 0) { 
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 13);
            }
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBroadsword);
            recipe.AddIngredient(null, "TwinklingStone", 5);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}