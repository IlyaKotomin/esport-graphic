using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuckGame;

namespace EsportGraphics.src.UI.Components
{
    internal class UIToggle : UIMenuItem
    {
        KeyValuePair<string, bool> _pair = new KeyValuePair<string, bool>();
        private UIOnOffCustom toggle;
        public bool activeted;
        public UIToggle(KeyValuePair<string, bool> pair, UIMenuAction action = null) : base(action)
        {
            _pair = pair;
            activeted = _pair.Value;
            Color c = Colors.MenuOption;

            UIDivider splitter = new UIDivider(true, 0f, 1f);
            UIText t = new UIText(_pair.Key, c, UIAlign.Center, 0f, null);
            t.align = UIAlign.Left;
            splitter.leftSection.Add(t, true);

            toggle = new UIOnOffCustom(-1f, -1f, _pair.Value);
            toggle.align = UIAlign.Right;
            splitter.rightSection.Add(toggle, true);

            _arrow = new UIImage("contextArrowRight", UIAlign.Left);
            _arrow.align = UIAlign.Right;
            _arrow.visible = false;
            leftSection.Add(this._arrow, true);

            controlString = "@CANCEL@BACK @WASD@ADJUST";
            rightSection.Add(splitter, true);
        }
        public override void Activate(string trigger)
        {
            if (trigger == "SELECT" || trigger == "MENURIGHT" || trigger == "MENULEFT")
            {
                activeted = !activeted;
            }
            
            if(_action != null)
                _action.Activate();

            toggle._setting = activeted;
            Config.ESConfig.Settings[_pair.Key] = activeted;
        }
    }
}
