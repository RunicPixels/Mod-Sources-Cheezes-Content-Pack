using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Guns
{
    public class TheHighNoon : ModItem
    {
        int magazineSize = 6;
        int maxMagazineSize = 6;
        int ReloadTime = 50;
        int DefaultUseTime = 4;
        bool shotPastReload = false;
        public override void SetDefaults()
        {

            item.damage = 59;
            item.ranged = true;
            item.width = 48;
            item.height = 26;
            item.scale = 0.7f;


            item.useTime = DefaultUseTime;
            item.useAnimation = DefaultUseTime;
            item.reuseDelay = 3;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4;
            item.value = 180000;
            item.rare = 5;
            item.crit = 6;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 20f;
            item.useAmmo = AmmoID.Bullet;
            item.useTurn = false;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("The High Noon");
      Tooltip.SetDefault("It's high noon.' This weapon is a reference from McCree from Overwatch.\nAlternative fire (Default: Right Mouse Button) rapidly shoots bullets in a spread. Has to reload every 6 shots.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
            recipe.AddIngredient(ItemID.AntlionMandible, 5);
            recipe.AddIngredient(ItemID.Cactus, 25);
            recipe.AddIngredient(null, "ShipWreckage", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            item.UseSound = SoundID.Item11;
            if (magazineSize <= 2)
            {
                Reload(player);
                magazineSize += 2;
            }
            else
            {
                item.reuseDelay = 3;
                item.useTime = DefaultUseTime;
                item.useAnimation = DefaultUseTime;
            }
            if (shotPastReload)
            {
                type = 0;
                shotPastReload = false;
                return false;
            }
            Main.PlaySound(2, player.position, 11);
            float spread = 0f;
            if (player.altFunctionUse == 2)
            {
                spread = 20f; // 20 degrees
                speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
                speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            }
            magazineSize--;
            SetMagazineToolTip(player);
            return true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public void Reload(Player player)
        {
            item.useTime = ReloadTime;
            item.useAnimation = ReloadTime;
            item.reuseDelay = ReloadTime;
            magazineSize = maxMagazineSize;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PistolReload");
            SetMagazineToolTip(player);
        }
        public void SetMagazineToolTip(Player player)
        {
            Rectangle rect = player.getRect();
            rect.Height = 0;
            rect.Width = 0;
            rect.X += 14;
            rect.Y += 30;
            if (magazineSize >= 7)
            {
                CombatText.NewText(rect,
                    Color.GhostWhite, (magazineSize - 20).ToString() + "/" + maxMagazineSize.ToString());
            }
            else if(magazineSize > -1)
            {
                CombatText.NewText(rect,
                    Color.GhostWhite, magazineSize.ToString() + " / " + maxMagazineSize.ToString());
            }
        }
    }
}
