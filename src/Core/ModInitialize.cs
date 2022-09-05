using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EsportGraphics.src.Core;

namespace EsportGraphics.src
{
    static class ModInitialize
    {
        public static void PreInitialize()
        {

        }
        public static void PostInitialize()
        {
            UpdateAndDraw.Initialize();
        }
    }
}
