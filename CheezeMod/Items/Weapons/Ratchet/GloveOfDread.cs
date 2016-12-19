using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class GloveOfDread : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Glove of Dread";
			item.damage = 27;
            item.summon = true;
			item.width = 60;
			item.height = 42;
            item.scale = 0.75f;
            item.mana = 12;
            item.toolTip = "Summons an agent of dread to fight for you, these now also shoot your enemies with lasers.";
            item.toolTip2 = "Originally from Ratchet and Clank.";
            item.useTime = 30;
            item.useAnimation = 30;
			item.useStyle = 1;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 180000;
            item.rare = CheezeItem.ratchetRarity[1];
            item.UseSound = SoundID.Item19;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("AgentOfDread"); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
            item.buffTime = 360000;
            item.buffType = mod.BuffType("AgentOfDread");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HellstoneBolt", 50);
            recipe.AddIngredient(null, "GloveOfDoom");
            recipe.AddIngredient(ItemID.ImpStaff);
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