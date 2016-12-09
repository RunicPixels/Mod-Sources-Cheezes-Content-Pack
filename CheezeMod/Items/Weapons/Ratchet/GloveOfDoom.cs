using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class GloveOfDoom : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Glove of Doom";
			item.damage = 15;
            item.summon = true;
			item.width = 60;
			item.height = 42;
            item.scale = 0.75f;
            item.mana = 8;
            item.toolTip = "Summons cool stuff.";
            item.toolTip2 = "Originally from Ratchet and Clank.";
            item.useTime = 35;
            item.useAnimation = 35;
			item.useStyle = 1;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 40000;
			item.rare = 2;
            item.UseSound = SoundID.Item19;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("AgentOfDoom"); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IronBolt", 50);
            recipe.AddRecipeGroup("CheezeMod:EvilLeather", 10);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 1f; // 1 degrees 
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, 'X');
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, 'Y');
            damage = (int)(damage * 0.6f);
            return true;
        }
        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(5) < 4; // 20%
        }
    }
}