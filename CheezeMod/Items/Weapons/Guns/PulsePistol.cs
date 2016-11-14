using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace CheezeMod.Items.Weapons.Guns
{
    public class PulsePistol : ModItem
    {
        int magazineSize = 20;
        int maxMagazineSize = 20;
        int DefaultUseTime = 5;
        int ReloadTime = 50;
        bool shotPastReload = false;
        public override void SetDefaults()
        {
            item.name = "Pulse Pistol";
            item.damage = 40;
            item.ranged = true;
            item.width = 44;
            item.height = 26;
            item.scale = 0.8f;
            SetMagazineToolTip();
            item.toolTip2 = "Originating by Tracer from Overwatch, rapidly fires in a spread.";
            AddTooltip2("Has to reload every 20 shots or with right click. Only consumes ammo half of the time.");
            item.useTime = DefaultUseTime;
            item.useAnimation = DefaultUseTime;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 1;
            item.value = 180001;
            item.rare = 5;
            item.useSound = 114;
            item.autoReuse = true;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 15f;
            item.useAmmo = ProjectileID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight, 3);
            recipe.AddIngredient(ItemID.CrystalShard, 15);
            recipe.AddRecipeGroup("CheezeMod:AdamantiteBars", 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            item.useSound = 114;
            if (magazineSize <= 2)
            {
                Reload(player);
                magazineSize += 2;
            }
            else
            {
                item.useTime = DefaultUseTime;
                item.useAnimation = DefaultUseTime;
            }
            if (shotPastReload)
            {
                type = 0;
                shotPastReload = false;
                return false;
            }
            float spread = 7f * 0.0174f; // 7 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
            speedX = baseSpeed * (float)Math.Sin(randomAngle);
            speedY = baseSpeed * (float)Math.Cos(randomAngle);
            magazineSize--;
            SetMagazineToolTip();
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("PulseGun");
            }
            return true;
        }
        public override bool AltFunctionUse(Player player)
        {
            if(magazineSize < maxMagazineSize)
            {
                Reload(player);
                shotPastReload = true;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public override bool ConsumeAmmo(Player p)
        {
            if (shotPastReload)
            {
                return false;
            }
            return Main.rand.Next(2) < 1; //50%
        }
        public void Reload(Player player)
        {
            item.useTime = ReloadTime;
            item.useAnimation = ReloadTime;
            magazineSize = maxMagazineSize;
            item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/PistolReload");
            SetMagazineToolTip();
        }
        public void SetMagazineToolTip()
        {
            if (magazineSize >= 21)
            {
                item.toolTip = (magazineSize-20).ToString() + "/" + maxMagazineSize.ToString() + " magazine left.";
            }
            else
            {
                item.toolTip = magazineSize.ToString() + "/" + maxMagazineSize.ToString() + " magazine left.";
            }
        }
    }
}