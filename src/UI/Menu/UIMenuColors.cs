using DuckGame;
using EsportGraphics.src.UI.Componets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI
{
    internal class UIMenuColors : UIMenuESG
    {
        public UIMenuColors(string name = "ESG Colors") : base(name)
        {
            GenerateColors();
        }
        private void GenerateColors()
        {
            foreach (var pair in Config.ESConfig.ESColors)
            {
                Add(new UIMenuItem(pair.Key ,new UIMenuActionOpenMenu(this, new UIMenuColorPicker(pair.Key, this))));
            }
        }
    }
}
