using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExampleMod.Items;
using BadUtils;

namespace DependentMod.Items {
public class DependentModItem : GlobalItem
{
    public override void SetDefaults(Item item)
    {
        if(item.type == ModLoader.GetMod("ExampleMod").ItemType("ExampleSword"))
        {
            item.damage = BadUtils.BadUtils.MysteryNumber();
        }
        if(item.modItem != null && item.modItem is ExampleItem)
        {
            item.modItem.AddTooltip("lol this artwork");
        }
    }
}}