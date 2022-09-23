using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI.Components
{
    internal class UIMenuItemSelectFont : UIMenuItem
    {
        private int _min;
        private int _max;
        private string _name;
        private int _value;

        private UIText _uiText;
        private UIText _textValue;
        public UIMenuItemSelectFont(string text, string name, Color color1, Color color2, int min = 0, int max = 255)
        {
            _min = min;
            _max = max;
            _name = name;
            _value = Config.ESConfig.Ints[_name];

            _uiText = new UIText(text, color1, UIAlign.Left, 0f, null);
            _uiText.align = UIAlign.Left;

            _textValue = new UIText(Config.ESConfig.Fonts[_value], color2, UIAlign.Right);

            _arrow = new UIImage("contextArrowRight", UIAlign.Left);
            _arrow.align = UIAlign.Right;
            _arrow.visible = false;
            leftSection.Add(_arrow, true);

            controlString = "@CANCEL@BACK @WASD@ADJUST";

            rightSection.Add(_uiText, true);
            rightSection.Add(_textValue, true);

            _textValue.anchor = this;
        }
        public override void Activate(string trigger)
        {
            int toChange = 1;
            if (Keyboard.shift)
                toChange = 10;


            if (trigger == "MENURIGHT" && _value + toChange <= _max)
            {
                _value += toChange;
            }
            else if (trigger == "MENULEFT" && _value - toChange >= _min)
            {
                _value -= toChange;
            }

            _textValue.text = Config.ESConfig.Fonts[_value];

            Config.ESConfig.Ints[_name] = _value;
        }
    }
}
