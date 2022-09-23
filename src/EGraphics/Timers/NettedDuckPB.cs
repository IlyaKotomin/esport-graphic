using DuckGame;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;
using static Config.ESConfig;

namespace EsportGraphics.src.EGraphics.Timers
{
    internal class NettedDuckPB : UpdateAndDraw
    {
        private Layer _layer = Layer.Foreground;
        public override void Draw()
        {
            if (!Settings["NettedDuckBar"])
                return;

            StartDraw(_layer);

            foreach (TrappedDuck trappedDuck in AvailableThings<TrappedDuck>())
                ESProgressBars.DrawLineBar(trappedDuck.bottomLeft,
                                           trappedDuck.bottomRight.x - trappedDuck.bottomLeft.x,
                                           1 - trappedDuck._trapTime,
                                           ESColors["BarFront"],
                                           ESColors["BarBack"],
                                           ESColors["BarOutLine"],
                                           2);

            StopDraw(_layer);
        }
    }
}
