using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            foreach (Door door in AvailableThings<Door>())
            {
                if (door._open == 1f || door._open == -1f)
                    door.material = new ColorMaterial(ESColors.OpenedDoor, true);
                else
                    door.material = new ColorMaterial(ESColors.ClosedDoor, true);
            }
        }
    }
}
