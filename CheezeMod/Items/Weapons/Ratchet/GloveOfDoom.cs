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

			item.damage = 15;
            item.summon = true;
			item.width = 60;
			item.height = 42;
            item.scale = 0.75f;
            item.mana = 8;


            item.useTime = 35;
            item.useAnimation = 35;
			item.useStyle = 1;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 40000;
            item.rare = CheezeItem.ratchetRarity[0];
            item.UseSound = SoundID.Item19;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("AgentOfDoom"); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
            item.buffTime = 360000;
            item.buffType = mod.BuffType("AgentOfDoom");
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Glove of Doom");
      Tooltip.SetDefault("Summons an agent of doom to fight for you.\nOriginally from Ratchet and Clank.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IronBolt", 50);
            recipe.AddIngredient(ItemID.SlimeStaff);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return true;
        }
    }
}
