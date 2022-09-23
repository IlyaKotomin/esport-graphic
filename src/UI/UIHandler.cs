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
        public static UIMenuMain mainMenu;
        public override bool NeedNetwork()
        {
            return false;
        }
        public override void Update()
        {
            if (Keyboard.Pressed(Keys.F7))
            {
                var ducknetMenu = (UIMenu)typeof(DuckNetwork).GetField("_ducknetMenu", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);

                if (ducknetMenu != null)
                    ducknetMenu.Close();


                mainMenu = new UIMenuMain();
                Level.Add(mainMenu);
                MonoMain.pauseMenu = mainMenu;
            }
        }
    }
}
