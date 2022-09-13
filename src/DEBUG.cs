using DuckGame;
using EsportGraphics.src.Core;
using EsportGraphics.src.Config;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System;
using Microsoft.Xna.Framework.Graphics;
using static EsportGraphics.src.Core.Utilites;
using EsportGraphics.src.EGraphics;

namespace EsportGraphics.src
{
    internal class DEBUG : UpdateAndDraw
    {
        private Layer _layer = Layer.HUD;
		public static bool downedItem;
		private static PhysicsObject holdMouseItem;
        private static SpriteMap _cursors = new SpriteMap("cursors", 16, 16, false);
        private static bool _enebled;
        public override void Update()
        {
            if (Keyboard.Pressed(Keys.Tab))
                _enebled = !_enebled;

            if (!Visible)
                return;

            Grabber();

            if (Keyboard.Pressed(Keys.F8))
                Config.ESOptions.Save();

            if (Keyboard.Pressed(Keys.F9))
                Config.ESOptions.Load();
        }

        private static void Grabber()
        {

            if (Keyboard.Down(Keys.MouseLeft) && !downedItem)
            {
                downedItem = true;
                if (holdMouseItem == null)
                {
                    holdMouseItem = Level.CheckCircle<PhysicsObject>(Mouse.positionScreen, 5f);
                }
            }

            if (holdMouseItem != null)
            {
                Thing.SuperFondle(holdMouseItem, DuckNetwork.localConnection);
                holdMouseItem.position = Mouse.positionScreen;
            }

            if (Keyboard.Released(Keys.MouseLeft))
            {
                downedItem = false;
                holdMouseItem = null;
            }
        }
        public override void Draw()
        {
            if (!_enebled)
                return;

            StartDraw(_layer);

            _cursors.position = Mouse.positionScreen;
            
            if (holdMouseItem != null)
                _cursors.frame = 5;
            else
                _cursors.frame = 1;

            _cursors.Draw();

            if (holdMouseItem == null)
            {
                var nearestObject = Level.Nearest<PhysicsObject>(Mouse.positionScreen);

                if (nearestObject != null)
                    Graphics.DrawLine(nearestObject.rectangle.Center, Mouse.positionScreen, ESColors.Blocks);
            }

            StopDraw(_layer);
        }
    }
}
