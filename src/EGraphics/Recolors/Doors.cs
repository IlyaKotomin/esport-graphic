using static Config.ESConfig;
using DuckGame;
using EsportGraphics.src.Core;
using EsportGraphics.src.Shaders;
using static EsportGraphics.src.Core.Utilites;

namespace EsportGraphics.src.EGraphics.Recolors
{
    internal class Doors : UpdateAndDraw
    {
        public override void Update()
        {
            if (Settings["Doors"])

            foreach (Door door in AvailableThings<Door>())
            {
                if (door._open == 1f || door._open == -1f)
                    door.material = new ColorMaterial(ESColors["DoorOpened"]);
                else
                    door.material = new ColorMaterial(ESColors["DoorClosed"]);
            }
        }
    }
}
