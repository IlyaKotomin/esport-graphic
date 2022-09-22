using DuckGame;
using EsportGraphics.src.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI.Componets
{
    internal class UIMenuColorPicker : UIMenu
    {
        private string rawName;
        private UIMenuItemColorPart r;
        private UIMenuItemColorPart g;
        private UIMenuItemColorPart b;
        private UIMenuItemColorPart a;
        private UIText textElement;
        public UIMenuColorPicker(string colorName, UIMenuColors closedMenu) : base("Color Picker",
                                             Layer.HUD.camera.width / 2f,
                                             Layer.HUD.camera.height / 2f,
                                             190f,
                                             -1f,
                                             "@DPAD@ADJUST @QUACK@SAVE",
                                             null,
                                             false)
        {
            rawName = colorName;
            textElement = new UIText(rawName, Color.White);

            Add(new UIText("", Color.White));
            Add(textElement);
            Add(new UIText("", Color.White));


            r = new UIMenuItemColorPart("R", colorName, ColorPart.R);
            g = new UIMenuItemColorPart("g", colorName, ColorPart.G);
            b = new UIMenuItemColorPart("b", colorName, ColorPart.B);
            a = new UIMenuItemColorPart("a", colorName, ColorPart.A);

            Add(r);
            Add(g);
            Add(b);
            Add(a);


            try
            {
                SetBackFunction(new UIMenuActionOpenMenu(this, closedMenu));
            }
            catch (Exception) { }
        }
        public override void Update()
        {
            base.Update();
            //textElement.text = $"|{r._value},{g._value},{b._value}|{rawName}";
        }
    }
}
