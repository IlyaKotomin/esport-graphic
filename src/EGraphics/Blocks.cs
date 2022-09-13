using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuckGame;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;

namespace EsportGraphics.src.EGraphics
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
        }
    }
}
