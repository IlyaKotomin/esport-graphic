using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI
{
    internal class UIMenuColors : UIMenu
    {
        private Dictionary<string, Color> _colors;
        public UIMenuColors(Dictionary<string, Color> colors) : base("@LWING@ESG Colors@RWING@",
                                             Layer.HUD.camera.width / 2f,
                                             Layer.HUD.camera.height / 2f,
                                             190f,
                                             -1f,
                                             "@DPAD@ADJUST @QUACK@BACK",
                                             null,
                                             false)
        {
            //Level.Add(this);
            //_colors = colors;
            //LoadColors();
        }
        private void LoadColors()
        {
        }
    }
}
