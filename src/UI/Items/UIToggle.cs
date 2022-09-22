using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuckGame;

namespace EsportGraphics.src.UI.Items
{
    internal class UIToggle : UIMenuItem
    {
        KeyValuePair<string, bool> _pair = new KeyValuePair<string, bool>();
        public bool activeted;
        public UIToggle(KeyValuePair<string, bool> pair)
        {
            _pair = pair;
            activeted = _pair.Value;
            Color c = Colors.MenuOption;

            UIDivider splitter = new UIDivider(true, 0f, 1f);
            if (_pair.Key != "")
            {
                UIText t = new UIText(_pair.Key, c, UIAlign.Center, 0f, null);
                t.align = UIAlign.Left;
                splitter.leftSection.Add(t, true);
            }

            UIOnOffCustom toggle = new UIOnOffCustom(-1f, -1f, _pair.Value);
            toggle.align = UIAlign.Right;
            splitter.rightSection.Add(toggle, true);

            base.rightSection.Add(splitter, true);
            this._arrow = new UIImage("contextArrowRight", UIAlign.Left);
            this.controlString = "@CANCEL@BACK @WASD@ADJUST";
        }
        public override void Activate(string trigger)
        {
            if (trigger == "SELECT" || trigger == "MENURIGHT")
            {
                activeted = true;
            }
            else if (trigger == "MENULEFT")
            {
                activeted = false;
            }
            SFX.Play("textLetter", 0.7f, 0f, 0f, false);
        }
    }
}
