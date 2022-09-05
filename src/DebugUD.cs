using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuckGame;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;

namespace EsportGraphics.src
{
    public class DebugUD : UpdateAndDraw
    {
        public override void Draw()
        {
            StartDraw(Layer.Foreground);

            foreach (Duck duck in Level.current.things[typeof(Duck)])
            {
                Graphics.DrawCircle(duck.position, duck.height, Color.White);
            }

            StopDraw(Layer.Foreground);
        }
    }
}
