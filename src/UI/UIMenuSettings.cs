using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Config.ESConfig;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI
{
    internal class UIMenuSettings : UIMenu
    {
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
        }
        private void GenerateSettings()
        {
            foreach (var pair in Settings)
                Add(new Items.UIToggle(pair));        
        }
        private void ChangeSetting(string name, UIMenuItem parent)
        {
            Settings[name] = !Settings[name];
        }
    }
}
