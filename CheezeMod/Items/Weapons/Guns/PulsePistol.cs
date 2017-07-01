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
        int DefaultUseTime = 4;
        int ReloadTime = 50;
        bool shotPastReload = false;
        public override void SetDefaults()
        {

            item.damage = 32;
            item.ranged = true;
            item.width = 44;
            item.height = 26;
            item.scale = 0.8f;
            SetMagazineToolTip();


            item.useTime = DefaultUseTime;
            item.useAnimation = DefaultUseTime;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 1;
            item.value = 180001;
            item.rare = 5;
            item.UseSound = SoundID.Item114;
            item.autoReuse = true;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 15f;
            item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pulse Pistol");
      Tooltip.SetDefault("Originating by Tracer from Overwatch, rapidly fires in a spread.\nOriginating by Tracer from Overwatch, rapidly fires in a spread.\nHas to reload every 20 shots or with right click. Only consumes ammo half of the time.");
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
            item.UseSound = SoundID.Item114;
            if (magazineSize <= 2)
            {
                Reload(player);
                magazineSize += 2;
            }
            else
            {
                item.reuseDelay = 0;
                item.useTime = DefaultUseTime;
                item.useAnimation = DefaultUseTime;
            }
            if (shotPastReload)
            {
                type = 0;
                shotPastReload = false;
                return false;
            }
            float spread = 17f; // 17 degrees
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
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
            item.reuseDelay = ReloadTime;
            magazineSize = maxMagazineSize;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PistolReload");
            SetMagazineToolTip();
        }
        public void SetMagazineToolTip()
        {
            if (magazineSize >= 21)
            {
                Tooltip.SetDefault("Originating by Tracer from Overwatch, rapidly fires in a spread.\nOriginating by Tracer from Overwatch, rapidly fires in a spread.\nHas to reload every 20 shots or with right click.Only consumes ammo half of the time.\n"+(magazineSize-20).ToString() + "/" + maxMagazineSize.ToString() + " magazine left.");
            }
            else
            {
                Tooltip.SetDefault("Originating by Tracer from Overwatch, rapidly fires in a spread.\nOriginating by Tracer from Overwatch, rapidly fires in a spread.\nHas to reload every 20 shots or with right click. Only consumes ammo half of the time.\n"+magazineSize.ToString() + " / " + maxMagazineSize.ToString() + " magazine left.");
            }
        }
    }
}
