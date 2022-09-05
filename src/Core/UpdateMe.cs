using System;
using System.Collections.Generic;
using System.Reflection;
using DuckGame;
using Microsoft.Xna.Framework;

namespace ModName.src.Core
{
    public abstract class UpdateMe : IUpdateable
    {
        public UpdateMe() => (typeof(Game).GetField("updateableComponents", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).GetValue(MonoMain.instance) as List<IUpdateable>).Add(this);
        public bool Enabled => true;
        public int UpdateOrder => 1;

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public void Update(GameTime gameTime) => Update();
        public virtual void Update() {}
    }
}
