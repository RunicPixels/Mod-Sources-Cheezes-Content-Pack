using System;
using Terraria;
using Terraria.ModLoader;

namespace DependentMod {
public class DependentMod : Mod
{
    public override void SetModInfo(out string name, ref ModProperties properties)
    {
        name = "DependentMod";
        properties.Autoload = true;
    }
}}