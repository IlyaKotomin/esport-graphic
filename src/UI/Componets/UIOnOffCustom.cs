using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI.Components
{
    public class UIOnOffCustom : UIText
    {
        public bool _setting;
        public UIOnOffCustom(float wide, float high, bool setting)
            : base("ON OFF", Color.White)
        {
            _setting = setting;
        }

        public override void Draw()
        {
            _font.scale = scale;
            _font.alpha = alpha;
            string text = "ON OFF";
            float num = _font.GetWidth(text);
            float num2 = (((align & UIAlign.Left) > UIAlign.Center) ? (0f - width / 2f) : (((align & UIAlign.Right) <= UIAlign.Center) ? ((0f - num) / 2f) : (width / 2f - num)));
            float num3 = (((align & UIAlign.Top) > UIAlign.Center) ? (0f - height / 2f) : (((align & UIAlign.Bottom) <= UIAlign.Center) ? ((0f - _font.height) / 2f) : (height / 2f - _font.height)));
            _font.Draw("ON", x + num2, y + num3, _setting ? Color.LightGreen : new Color(70, 70, 70), depth);
            _font.Draw("   OFF", x + num2, y + num3, (!_setting) ? Color.LightPink : new Color(70, 70, 70), depth);
        }
    }
}
