using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.UI.Menu
{
	public class UIColorSlider : UIComponent
	{
		public UIColorSlider(float wide, float high, int volue, string colorName , Color increment = default(Color), string append = "") : base(0f, 0f, 0f, 0f)
		{
			this._collisionSize = new Vec2(30f, high);
			this._barSize = new Vec2(wide, high);
			this._increment = increment;
			this._append = append;
			this._volue = volue;
			this._colorName = colorName;
		}

		public override void Draw()
		{
			if (base.rootMenu.mode == MenuItemMode.Hidden)
			{
				return;
			}
			string text = this._volue.ToString() + this._append;
			Vec2 position = this.position - new Vec2(Graphics.GetStringWidth(text, false, 1f) / 2f, Graphics.GetStringHeight(text) / 2f);
			Vec2 vec = this.position - new Vec2(this._barSize.x + Graphics.GetStringWidth("   " + this._append, false, 1f), base.halfHeight);
			Vec2 value = new Vec2(this._barSize.x, this._barSize.y);
			Vec2 vec2 = vec + new Vec2((value.x - 4f) * (float)(_volue) / 255f, 0f);
			Graphics.DrawRect(vec2, vec2 + new Vec2(4f, base.height), Color.White, base.depth + 1, true, 1f);
			if (this._parent.parent.parent.parent.mode == MenuItemMode.Disabled)
			{
				Color color = new Color(70, 70, 70);
				Graphics.DrawString(text, position, color, base.depth, null, 1f);
				Graphics.DrawRect(vec, vec + value, color, base.depth, true, 1f);
				return;
			}
			Color col = Config.ESConfig.ESColors[_colorName];
			col = new Color(col.ToVector3() - this._increment.ToVector3());
			float num = (float)Math.Round(Convert.ToDouble(value.x / 2f));
			int num2 = 1;
			while ((float)num2 <= num)
			{
				col = new Color(col.ToVector3() + this._increment.ToVector3() / num);
				Graphics.DrawRect(new Vec2(vec.x + value.x / num * (float)(num2 - 1), vec.y), new Vec2(vec.x + value.x / num * (float)num2, vec.y + value.y), col, base.depth, true, 1f);
				num2++;
			}
			Graphics.DrawString(text, position, Color.White, base.depth, null, 1f);
		}
		private int _volue;

		private string _colorName;

		private Color _increment;

		private string _append;

		private Vec2 _barSize;
	}
}
