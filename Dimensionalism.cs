using Terraria.ModLoader;
using SubworldLibrary;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Dimensionalism
{
	public class Dimensionalism : Mod
	{
        public override void Load()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                Ref<Effect> filterRef = new Ref<Effect>(Request<Effect>("Dimensionalism/Effects/Filters/Test", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value);
                Filters.Scene["Test"] = new Filter(new ScreenShaderData(filterRef, "FilterMyShader").UseColor(1, 0, 0));
                
                
            }
        }
    }
}