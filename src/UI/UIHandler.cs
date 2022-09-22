using DuckGame;
using EsportGraphics.src.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI
{
    internal class UIHandler : UpdateAndDraw
    {
        public override void Update()
        {
            if (Keyboard.Pressed(Keys.F7))
                new UIEsportGraphicsMenu(new UIMenuSettings(), new UIMenuColors(Config.ESConfig.ESColors)).Open();
        }
    }
}
