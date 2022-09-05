using DuckGame;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;

namespace EsportGraphics.src
{
    internal class DrawAndUpdateClass : UpdateAndDraw
    {
        private Layer _layer = Layer.Foreground;
        public override void Draw()
        {
            StartDraw(_layer);
            
            //Draw code here

            StopDraw(_layer);
        }
        public override void Update()
        {
            //Update code here
        }
    }
}
