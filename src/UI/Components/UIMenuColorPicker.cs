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
        public UIMenuColorPicker(string colorName, UIMenuColors closedMenu) : base(colorName,
                                             Layer.HUD.camera.width / 2f,
                                             Layer.HUD.camera.height / 2f,
                                             190f,
                                             -1f,
                                             "@DPAD@ADJUST @QUACK@SAVE",
                                             null,
                                             false)
        {
            rawName = colorName;

            Add(new UIText("", Color.White));
            Add(new UIText("Press shift to +10", Color.Gray));
            Add(new UIText("", Color.White));

            Add( new UIMenuItemColorPart("R", colorName, ColorPart.R));
            Add( new UIMenuItemColorPart("G", colorName, ColorPart.G));
            Add( new UIMenuItemColorPart("B", colorName, ColorPart.B));
            Add( new UIMenuItemColorPart("A", colorName, ColorPart.A));

            Add(new UIText("", Color.White));

            SetBackFunction(new UIMenuActionOpenMenu(this, closedMenu));
        }
        public override void Draw()
        {
            base.Draw();

            Graphics.DrawStringOutline("Preview:", new Vec2(x - halfWidth, y - halfHeight - 34), Color.LightGray, Color.Black);

            Rectangle rectangle = new Rectangle(x - halfWidth, y - halfHeight - 23, width, 20);
            Rectangle border = new Rectangle(new Vec2(rectangle.tl.x - 1, rectangle.tl.y - 1), new Vec2(rectangle.br.x + 1, rectangle.br.y + 1));
            Graphics.DrawRect(rectangle, Config.ESConfig.ESColors[rawName]);
            Graphics.DrawRect(border , Color.Black, borderWidth: 2, filled: false, depth: + 1);

            Graphics.DrawRect(rectangle, Color.Gray, borderWidth: 3, filled: false, depth: + 2);
            Graphics.DrawRect(rectangle, Color.DarkGray, borderWidth: 2, filled: false, depth: + 2);
            Graphics.DrawRect(rectangle, Color.LightGray, borderWidth: 1, filled: false, depth: + 2);
        }
    }
}
