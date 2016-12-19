using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class UltraGloveOfDread : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ultra Glove of Dread";
			item.damage = 100;
            item.summon = true;
			item.width = 60;
			item.height = 42;
            item.scale = 0.75f;
            item.mana = 20;
            item.toolTip = "Summons an ultra agent of dread to fight for you, the agents now have unlimited flight as well as enhanced weaponry.";
            item.toolTip2 = "Originally from Ratchet and Clank.";
            item.useTime = 25;
            item.useAnimation = 25;
			item.useStyle = 1;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 960000;
            item.rare = CheezeItem.ratchetRarity[3];
            item.UseSound = SoundID.Item19;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("UltraAgentOfDread"); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
            item.buffTime = 360000;
            item.buffType = mod.BuffType("UltraAgentOfDread");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LuminiteBolt", 50);
            recipe.AddIngredient(ItemID.FragmentStardust, 15);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 100);
            recipe.AddIngredient(null, "MegaGloveOfDread");
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 1f; // 1 degrees 
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            return true;
        }
    }
}