using DuckGame;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;

namespace EsportGraphics.src.EGraphics
{
    internal class Ducks : UpdateAndDraw
    {
        private Layer _layer = Layer.Foreground;
        public override void Draw()
        {
            StartDraw(_layer);
            
            foreach (Duck duck in AvailableThings(typeof(Duck)))
                if (!Keyboard.Down(Keys.Tab) && !duck.isLocal)
                    duck.blendColor = Color.Red;

            StopDraw(_layer);
        }
        public override void Update()
        {
            //Update code here
        }
    }
}
