using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Config.ESConfig;
using System.Threading.Tasks;
using EsportGraphics.src.UI.Components;
using System.Reflection;
using EsportGraphics.src.UI.Componets;

namespace EsportGraphics.src.UI
{
    internal class UIMenuSettings : UIMenuESG
    {
        public UIMenuSettings(string name = "ESG Settings") : base(name)
        {
            GenerateSettings();
        }
        private void GenerateSettings()
        {
            foreach (var pair in Settings)
                Add(new UIToggle(pair));
        }
    }
}
