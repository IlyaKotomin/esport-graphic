using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.Core
{
    internal static class Utilites
    {
        public static void StartDraw(Layer layer) => layer.Begin(true);
        public static void StopDraw(Layer layer) => layer.End(true);
    }
}
