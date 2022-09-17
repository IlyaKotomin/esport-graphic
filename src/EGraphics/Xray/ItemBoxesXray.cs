using DuckGame;
using EsportGraphics.src.Core;
using EsportGraphics.src.Shaders;
using static EsportGraphics.src.Core.Utilites;
using static Config.ESConfig;
using System;
using System.Reflection;

namespace EsportGraphics.src.EGraphics.Xray
{
    internal class ItemBoxesXray : UpdateAndDraw
    {
        private Layer _layer = Layer.Blocks;
        public override void Update()
        {
            if (Keyboard.Pressed(Keys.P))
                Level.Add(new ItemBoxRandom(Mouse.x, Mouse.y));
        }
        public override void Draw()
        {
            if (!Settings["Xray"])
                return;

            StartDraw(_layer);

            foreach(ItemBox box in AvailableThings<ItemBox>())
            {
                if (box is not PurpleBlock && box.containedObject != null)
                {
                    Sprite _containedSprite = box.containedObject.graphic;
                    _containedSprite.alpha = Floats["XrayAlpha"];
                    _containedSprite.CenterOrigin();
                    Graphics.Draw(_containedSprite, box.x, box.y - 20);
                }
            }

            StopDraw(_layer);
        }
    }
}
