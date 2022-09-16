using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DuckGame;
using EsportGraphics.src.Core;
using EsportGraphics.src.Shaders;
using static EsportGraphics.src.Core.Utilites;

namespace EsportGraphics.src.EGraphics.Recolors
{
    internal class Blocks : UpdateAndDraw
    {
        private Layer _layer = Layer.Foreground;
        public override void Draw()
        {
            //StartDraw(_layer);

            //foreach (Block block in Utilites.AvailableThings(typeof(Block)))
            //{
            //    Graphics.DrawRect(block.rectangle, ESColors.Blocks * 0.5f);
            //}

            //StopDraw(_layer);
        }
        public override void Update()
        {
            foreach (AutoBlock block in AvailableThings<AutoBlock>())
                block.material = new ColorMaterial(ESColors.Blocks, true);

            foreach (Thing platform in AvailableThings<Thing>())
                if (platform is IPlatform && platform is not PhysicsObject && platform is not Block)
                    platform.material = new ColorMaterial(ESColors.Blocks, true);

            //foreach(BackgroundTile thing in AvailableThings(typeof(BackgroundTile)))
            //    Level.Remove(thing);
        }
    }
}
