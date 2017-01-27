using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Bows
{
    public class CallistoBow : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Callisto Bow";
            item.damage = 60;
            item.ranged = true;
            item.width = 28;
            item.height = 56;
            item.toolTip = "This a bow from a far moon. \n+40% Increased Critical Damage.\n Has a 33% chance to shoot an extra arrow.";
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5;
            item.scale = 1f;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 500000;
            item.rare = 8;
            item.crit = 15;
            item.autoReuse = true;
            item.UseSound = SoundID.Item5;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 15f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(Main.rand.Next(3) == 0)
            {
                float speedMod = 0.7f + Main.rand.NextFloat() * 0.5f;
                Projectile.NewProjectile(position.X-(speedX*2), position.Y- (speedY * 2), speedX *speedMod, speedY* speedMod, type, damage, knockBack, item.owner);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.4f; // This number here changes the multiplier
            }
        }
    }
}