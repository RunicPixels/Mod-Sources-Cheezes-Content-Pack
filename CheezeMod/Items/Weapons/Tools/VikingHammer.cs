using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Tools
{
    public class VikingHammer : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 19;
            item.melee = true;
            item.width = 36;
            item.height = 36;

            item.useTime = 36;
            item.scale = 1.33f;
            item.useAnimation = 36;
            item.hammer = 55;
            item.useStyle = 1;
            item.knockBack = 6f;
            item.value = 2400;
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Viking Hammer");
            Tooltip.SetDefault("It's a viking hammer, often used in norse smithing.");
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "VikingHammerHead", 1);
            recipe.AddIngredient(ItemID.BorealWood, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}