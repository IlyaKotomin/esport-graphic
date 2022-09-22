using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsportGraphics.src.UI;

namespace EsportGraphics.src.UI.Componets
{
    internal class UIMenuESG : UIMenu
    {
        public UIMenuESG(string name) : base("@LWING@" + name + "@RWING@",
                                             Layer.HUD.camera.width / 2f,
                                             Layer.HUD.camera.height / 2f,
                                             190f,
                                             -1f,
                                             "@DPAD@ADJUST @QUACK@BACK",
                                             null,
                                             false)
        {
            SetBackFunction(new UIMenuActionCloseMenuCallFunction(this,
                new UIMenuActionCloseMenuCallFunction.Function(OpenClosedMenu)));
        }
        private void OpenClosedMenu()
        {
            new UIMenuMain().Open();
        }
    }
}
