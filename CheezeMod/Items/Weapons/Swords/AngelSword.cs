using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
    public class AngelSword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Angel Sword";
            item.damage = 40;
            item.melee = true;
            item.width = 44;
            item.height = 44;
            item.toolTip = "An sword that once used by the angels of Madrigal. \n+12% increased Critical hit chance, critical hit damage and movement speed. \n Inflics Angel's Bane on enemy hit.";
            item.crit = 12;
            item.scale = 1.1f;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = CheezeItem.historicPrice;
            item.rare = CheezeItem.historicRarity;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AngelEssence", 5);
            recipe.AddIngredient(ItemID.PearlwoodSword);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(20) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 55);
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.12f; // This number here changes the multiplier
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).flyffangelic = true; // Angel debuff on enemy for 1 sec.
                player.maxRunSpeed *= 1.12f;
                player.jumpSpeedBoost *= 1.12f;
            }
        }
    }
}