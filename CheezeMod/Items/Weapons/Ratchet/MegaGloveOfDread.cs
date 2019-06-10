using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class MegaGloveOfDread : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 45;
            item.summon = true;
			item.width = 60;
			item.height = 42;
            item.scale = 0.75f;
            item.mana = 18;


            item.useTime = 25;
            item.useAnimation = 25;
			item.useStyle = 1;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 540000;
            item.rare = CheezeItem.ratchetRarity[2];
            item.UseSound = SoundID.Item19;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("MegaAgentOfDread"); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
            item.buffTime = 360000;
            item.buffType = mod.BuffType("MegaAgentOfDread");
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mega Glove of Dread");
      Tooltip.SetDefault("Summons an mega agent of dread to fight for you, now also comes with bombs.\nOriginally from Ratchet and Clank.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HallowedBolt", 50);
            recipe.AddIngredient(ItemID.SoulofSight, 2);
            recipe.AddIngredient(null, "GloveOfDread");
            recipe.AddIngredient(ItemID.SpiderStaff);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 1f; // 1 degrees 
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.X);
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.Y);
            return true;
        }
    }
}
