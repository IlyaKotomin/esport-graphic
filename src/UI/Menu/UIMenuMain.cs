using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI
{
    internal class UIMenuMain : UIMenu
    {
        public UIMenuMain() : base("@LWING@Esport Graphics@RWING@",
                                             Layer.HUD.camera.width / 2f,
                                             Layer.HUD.camera.height / 2f,
                                             190f,
                                             -1f,
                                             "@DPAD@ADJUST @QUACK@BACK",
                                             null,
                                             false)
        {
            Add(new UIMenuItem("Settings", new UIMenuActionOpenMenu(this, new UIMenuSettings())));
            Add(new UIMenuItem("Colors", new UIMenuActionOpenMenu(this, new UIMenuColors())));
            Add(new UIMenuItem("Ammo Counter Font"));

            SetBackFunction(new UIMenuActionOpenMenu(this, new UIMenuSaveSettings()));
        }
        public override void Open()
        {
            var ducknetMenu = (UIMenu)typeof(DuckNetwork).GetField("_ducknetMenu", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);

            if (ducknetMenu != null)
                ducknetMenu.Close();

            Level.Add(this);
            MonoMain.pauseMenu = this;
        }
    }
}
