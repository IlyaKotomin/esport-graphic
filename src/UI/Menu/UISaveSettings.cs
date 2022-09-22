using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI
{
    internal class UISaveSettings : UIMenu
    {
        public UISaveSettings() : base("@LWING@Esport Graphics@RWING@",
                                             Layer.HUD.camera.width / 2f,
                                             Layer.HUD.camera.height / 2f,
                                             190f,
                                             -1f,
                                             "@DPAD@ADJUST @QUACK@SAVE",
                                             null,
                                             false)
        {
            Add(new UIText(" ", Color.White));
            Add(new UIText("Save Settings?", Color.Pink));
            Add(new UIText(" ", Color.White));

            var closeAndSave = new UIMenuActionCloseMenuCallFunction(this,
                new UIMenuActionCloseMenuCallFunction.Function(Config.ESConfig.SaveAll));

            Add(new UIMenuItem("YES", closeAndSave, UIAlign.Center, Color.LimeGreen));

            Add(new UIMenuItem("NO", new UIMenuActionCloseMenu(this), UIAlign.Center, Color.Red));

            SetBackFunction(closeAndSave);
        }
    }
}
