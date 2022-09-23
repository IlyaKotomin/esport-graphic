using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DuckGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EsportGraphics.src.Core
{
    public abstract class UpdateAndDraw : IUpdateable, IDrawable
    {
        public Layer Layer;
        public UpdateAndDraw()
        {
            (typeof(Game).GetField("updateableComponents",
                BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.NonPublic)
                .GetValue(MonoMain.instance) as List<IUpdateable>).Add(this);

            (typeof(Game).GetField("drawableComponents",
                BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.NonPublic)
                .GetValue(MonoMain.instance) as List<IDrawable>).Add(this);
        }
        public static void Initialize()
        {
            IEnumerable<Type> updateList = Assembly.GetAssembly(typeof(UpdateAndDraw)).GetTypes().Where(type => type.IsSubclassOf(typeof(UpdateAndDraw)));

            foreach (Type updateItem in updateList) { UpdateAndDraw instance = (UpdateAndDraw)Activator.CreateInstance(updateItem); }
        }
        public bool Enabled => true;
        public int UpdateOrder => 1;

        public virtual bool NeedNetwork()
        {
            return true;
        }
        public virtual bool Visible { get { return true; } set { } }

        public int DrawOrder => 1;

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public void Draw(GameTime gameTime)
        {
            if (Level.current is RockScoreboard or TeamSelect2 || !DuckNetwork.active || MonoMain.pauseMenu != null)
                return;

            Graphics.screen.Begin(SpriteSortMode.BackToFront,
                                      BlendState.NonPremultiplied,
                                      SamplerState.PointClamp,
                                      DepthStencilState.Default,
                                      RasterizerState.CullNone,
                                      null,
                                      Microsoft.Xna.Framework.Matrix.Identity);

            Draw();
            Graphics.screen.End();
        }
        public virtual void Draw() { }
        public void Update(GameTime gameTime)
        {
            bool onNetwork = NeedNetwork() ? DuckNetwork.active : true;

            if (Level.current is not RockScoreboard or TeamSelect2 && onNetwork)
                Update();
        }
        public virtual void Update() { }
    }
}
