using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
	public class ChronicleSword : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Chronicle Sword";
			item.damage = 120;
			item.melee = true;
			item.width = 52;
			item.height = 52;
			item.toolTip = "It's from a Dark Chronicle.";
            item.toolTip2 = "Sends out three blasts that have a chance to inflict cursed flames or ichor.";
            item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 500000;
            item.scale = 1f;
			item.rare = 8;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 12f;
		}

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(7) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("DarkSparkle"));
            }
            if (Main.rand.Next(7) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("ShortSparkle"));
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            damage = 45;
            knockBack = 2;
            type = mod.ProjectileType("HolyBlast");
            float spread = 10f * 0.0174f; // 10 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double[] Angle = { baseAngle + -1 * spread, baseAngle + 0 * spread, baseAngle + 1 * spread };
            float[] speedXArray = { baseSpeed * (float)Math.Sin(Angle[0]) , baseSpeed * (float)Math.Sin(Angle[1]) , baseSpeed * (float)Math.Sin(Angle[2]) };
            float[] speedYArray = { baseSpeed * (float)Math.Cos(Angle[0]) , baseSpeed * (float)Math.Cos(Angle[1]) , baseSpeed * (float)Math.Cos(Angle[2]) };
            for(int i = 0;i <= speedXArray.Length; i++) {
                Projectile.NewProjectile(position.X, position.Y, speedXArray[i],speedYArray[i],type,damage,knockBack, item.owner);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlwoodSword);
            recipe.AddIngredient(ItemID.Excalibur);
            recipe.AddIngredient(ItemID.Ectoplasm, 7);
            recipe.AddIngredient(ItemID.SoulofLight, 7);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}