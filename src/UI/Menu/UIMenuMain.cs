using DuckGame;
using EsportGraphics.src.UI.Menu;
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
            Add(new UIText("", Color.LightGray));
            Add(new UIText("BASICS", Color.LightGray) { scale = new Vec2(1.3f) });
            Add(new UIText("", Color.LightGray));

            Add(new UIMenuItem("Settings", new UIMenuActionOpenMenu(this, new UIMenuSettings(this))));
            Add(new UIMenuItem("Colors", new UIMenuActionOpenMenu(this, new UIMenuColors(this))));

            Add(new UIText("", Color.LightGray));
            Add(new UIText("OTHER", Color.LightGray) { scale = new Vec2(1.3f) });
            Add(new UIText("", Color.LightGray));

            Add(new UIMenuItem("Ammo Counter", new UIMenuActionOpenMenu(this, new UIMenuAmmoCounter(this))));
            Add(new UIMenuItem("Credits"));
            Add(new UIMenuItem("Open Configs Folder"));

            Add(new UIText("", Color.LightGray));

            SetBackFunction(new UIMenuActionOpenMenu(this, new UIMenuSaveSettings(this)));
        }
    }
}
