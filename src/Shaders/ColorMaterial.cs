using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuckGame;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace EsportGraphics.src.Shaders
{
    internal class ColorMaterial : Material
    {
        private Color _color;
        private float _greyStyle;
        public ColorMaterial(Color color, bool greyStyle = false)
        {
            _color = color;
            _greyStyle = Convert.ToSingle(greyStyle);
            _effect = ShaderLoader.mtEffects["color"];
        }
        public override void Apply()
        {
            SetValue("overlay_color", _color);
            SetValue("greyStyle", _greyStyle);
            base.Apply();
        }
    }
}
