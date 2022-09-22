using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Config.ESConfig;
using System.Threading.Tasks;
using EsportGraphics.src.UI.Components;
using System.Reflection;

namespace EsportGraphics.src.UI
{
    internal class UIMenuSettings : UIMenu
    {
        private UIEsportGraphicsMenu closedMenu;
        public UIMenuSettings() : base("@LWING@ESG Settings@RWING@",
                                             Layer.HUD.camera.width / 2f,
                                             Layer.HUD.camera.height / 2f,
                                             190f,
                                             -1f,
                                             "@DPAD@ADJUST @QUACK@BACK",
                                             null,
                                             false)
        {
            GenerateSettings();

            SetBackFunction(new UIMenuActionCloseMenuCallFunction(this,
                new UIMenuActionCloseMenuCallFunction.Function(OpenClosedMenu)));
        }
        private void GenerateSettings()
        {
            foreach (var pair in Settings)
                Add(new UIToggle(pair));
        }
        private void OpenClosedMenu()
        {
            new UIEsportGraphicsMenu().Open();
        }
    }
}
