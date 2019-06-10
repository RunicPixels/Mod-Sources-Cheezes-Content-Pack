using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Magic
{
    public class GraniteRod : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 20;
            item.magic = true;
            item.mana = 6;
            item.width = 42;
            item.height = 42;
            item.channel = true;

            Item.staff[item.type] = true;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = 25000;
            item.rare = 1;
            item.UseSound = SoundID.Item12;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BlueLaserStaff");
            item.shootSpeed = 23f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Granite Rod");
      Tooltip.SetDefault("Shoots a resonating beam.");
    }


        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 0.2f; // 0.2 degrees
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.X);
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.Y);
            return true;
        }
    }
}
