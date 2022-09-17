using DuckGame;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;
using static Config.ESConfig;

namespace EsportGraphics.src.EGraphics.Recolors
{
    internal class Spikes : UpdateAndDraw
    {
        public override void Update()
        {
            if (!Settings["Spikes"])
                return;

            foreach (DuckGame.Spikes spikes in AvailableThings<DuckGame.Spikes>())
                spikes.material = new Shaders.ColorMaterial(ESColors["Spikes"]);
        }
    }
}
