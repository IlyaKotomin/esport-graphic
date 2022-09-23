using DuckGame;
using static Config.ESConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI.Components
{
    internal class UIMenuItemCounter : UIMenuItem
    {
        private int _min;
        private int _max;
        private string _floatName;
        private float _value;

        private UIText _uiText;
        private UIText _textValue;
        public UIMenuItemCounter(string text, string floatName, Color color1, Color color2, int min = 0, int max = 255)
        {
            _min = min;
            _max = max;
            _floatName = floatName;
            _value = Floats[_floatName];

            UIDivider splitter = new UIDivider(true, 0f, 1f);
            _uiText = new UIText(text, color1, UIAlign.Left, 0f, null);
            _uiText.align = UIAlign.Left;
            splitter.leftSection.Add(_uiText, true);

            _textValue = new UIText(_value.ToString(), Color.White, UIAlign.Right);
            splitter.rightSection.Add(_textValue, true);

            _arrow = new UIImage("contextArrowRight", UIAlign.Left);
            _arrow.align = UIAlign.Right;
            _arrow.visible = false;
            leftSection.Add(this._arrow, true);

            controlString = "@CANCEL@BACK @WASD@ADJUST";
            rightSection.Add(splitter, true);

            _textValue.anchor = this;
        }
        public override void Activate(string trigger)
        {
            float toChange = 0.1f;
            if (Keyboard.shift)
                toChange = 1f;


            if (trigger == "MENURIGHT" && _value + toChange <= _max)
            {
                _value += toChange;
            }
            else if (trigger == "MENULEFT" && _value - toChange >= _min)
            {
                _value -= toChange;
            }

            _textValue.text = _value.ToString();

            Floats[_floatName] = _value;
        }
    }
}
