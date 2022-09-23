using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI
{
    internal class UIMenuSaveSettings : UIMenu
    {
        public UIMenuSaveSettings(UIMenu closedMenu) : base("Esport Graphics",
                                             Layer.HUD.camera.width / 2f,
                                             Layer.HUD.camera.height / 2f,
                                             190f,
                                             -1f,
                                             "@DPAD@ADJUST @QUACK@BACK",
                                             null,
                                             false)
        {
            var closeAndSave = new UIMenuActionCloseMenuCallFunction(this,
                new UIMenuActionCloseMenuCallFunction.Function(Config.ESConfig.SaveAll));

            Add(new UIText("", Color.LightGray));
            Add(new UIText("Save Settings?", Color.LightGray) { scale = new Vec2(1.3f) });
            Add(new UIText("", Color.LightGray));

            Add(new UIMenuItem("YES", closeAndSave, UIAlign.Center, Color.LimeGreen));
            Add(new UIText("", Color.LightGray));
            Add(new UIMenuItem("NO", new UIMenuActionCloseMenu(this), UIAlign.Center, Color.Red));
            Add(new UIText("", Color.LightGray));

            SetBackFunction(new UIMenuActionOpenMenu(this, closedMenu));
        }
    }
}
