﻿using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI.Components
{
    internal class UIMenuItemColorPart : UIMenuItem
    {
        private UIText _uiText;
        private UIText _textValue;
        private ColorPart _part;
        private string _colorName;
        public int _value;
        private int _min;
        private int _max;
        public UIMenuItemColorPart(string text, string colorName, ColorPart part, int min = 0, int max = 255)
        {
            _min = min;
            _max = max;
            _part = part;
            _colorName = colorName;

            UIDivider splitter = new UIDivider(true, 0f, 1f);
            _uiText = new UIText(text, GetColor(_part), UIAlign.Center, 0f, null);
            _uiText.align = UIAlign.Left;
            splitter.leftSection.Add(_uiText, true);

            _textValue = new UIText("0", Color.White, UIAlign.Right);
            splitter.rightSection.Add(_textValue, true);

            _arrow = new UIImage("contextArrowRight", UIAlign.Left);
            _arrow.align = UIAlign.Right;
            _arrow.visible = false;
            leftSection.Add(this._arrow, true);

            controlString = "@CANCEL@BACK @WASD@ADJUST";
            rightSection.Add(splitter, true);
        }
        public override void Activate(string trigger)
        {
            if (trigger == "MENURIGHT" && _value < _max)
            {
                _value++;
            }
            else if(trigger == "MENULEFT" && _value > _min)
            {
                _value--;
            }

            _textValue.text = _value.ToString();

            UpdateColorConfig(_part);
        }
        private Color GetColor(ColorPart part)
        {
            return part switch
            {
                ColorPart.R => new Color(255, 0, 0),
                ColorPart.G => new Color(0, 255, 0),
                ColorPart.B => new Color(0, 0, 255),
                ColorPart.A => new Color(255, 255, 255),
                _ => new Color(255, 255, 255)
            };
        }
        private void UpdateColorConfig(ColorPart part)
        {
            Color color = Config.ESConfig.ESColors[_colorName];

            switch (part)
            {
                case ColorPart.R:
                    color.r = (byte)_value;
                    break;
                case ColorPart.G:
                    color.g = (byte)_value;
                    break;
                case ColorPart.B:
                    color.b = (byte)_value;
                    break;
                case ColorPart.A:
                    color.a = (byte)_value;
                    break;
            }

            Config.ESConfig.ESColors[_colorName] = color;
        }
    }
}
