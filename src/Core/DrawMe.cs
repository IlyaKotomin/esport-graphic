using System;
using System.Collections.Generic;
using System.Reflection;
using DuckGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ModName.src.Core
{
    public abstract class DrawMe : IDrawable
    {
        public DrawMe() => (typeof(Game).GetField("drawableComponents", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).GetValue(MonoMain.instance) as List<IDrawable>).Add(this);
        public bool Visible => true;
        public int DrawOrder => 1;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public void Draw(GameTime gameTime)
        {
            Graphics.screen.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Microsoft.Xna.Framework.Matrix.Identity);
            Draw();
            Graphics.screen.End();
        }
        public virtual void Draw() { }
    }
}
