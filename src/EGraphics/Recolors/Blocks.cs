using DuckGame;
using EsportGraphics.src.Core;
using EsportGraphics.src.Shaders;
using static EsportGraphics.src.Core.Utilites;
using static Config.ESConfig;

namespace EsportGraphics.src.EGraphics.Recolors
{
    internal class Blocks : UpdateAndDraw
    {   
        public override void Update()
        {
            if (!Settings["Blocks"])
                return;

            foreach (AutoBlock block in AvailableThings<AutoBlock>())
                block.material = new ColorMaterial(ESColors["Blocks"], true);

            foreach (Thing platform in AvailableThings<Thing>())
                if (platform is IPlatform && platform is not PhysicsObject && platform is not Block)
                    platform.material = new ColorMaterial(ESColors["Blocks"], true);

            //foreach(BackgroundTile thing in AvailableThings(typeof(BackgroundTile)))
            //    Level.Remove(thing);
        }
    }
}
