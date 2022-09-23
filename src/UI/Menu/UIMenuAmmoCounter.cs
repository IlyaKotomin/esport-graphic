using DuckGame;
using EsportGraphics.src.UI.Components;
using EsportGraphics.src.UI.Componets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI.Menu
{
    internal class UIMenuAmmoCounter : UIMenuESG
    {
        public UIMenuAmmoCounter(UIMenu closedMenu, string name = "Ammo Counter") : base(name, closedMenu)
        {
            Add(new UIMenuItemSelectFont("Font", "AmmoCounterFont", Colors.MenuOption, Color.White, 0, Config.ESConfig.Fonts.Length - 1));
            Add(new UIMenuItemCounter("Scale", "AmmoCounterScale", Colors.MenuOption, Color.White, 0f, 20f));
        }
    }
}
