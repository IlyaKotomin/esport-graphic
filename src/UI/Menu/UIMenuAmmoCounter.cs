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
            GenerateUIItems();
            
        }
        private void GenerateUIItems()
        {
            foreach (var pair in Config.ESConfig.Floats)
            {
                Add(new UIMenuItemCounter(pair.Key, pair.Key, Colors.MenuOption, Color.White, 0, 20));
            }
        }
    }
}
