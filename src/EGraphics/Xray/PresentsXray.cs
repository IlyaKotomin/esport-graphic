﻿using DuckGame;
using EsportGraphics.src.Core;
using EsportGraphics.src.Shaders;
using static EsportGraphics.src.Core.Utilites;
using static Config.ESConfig;
using System;
using System.Reflection;

namespace EsportGraphics.src.EGraphics.Xray
{
    internal class PresentsXray : UpdateAndDraw
    {
        private Layer _layer = Layer.Blocks;
        public override void Draw()
        {
            if (!Settings["Xray"])
                return;

            StartDraw(_layer);

            foreach (Present present in AvailableThings<Present>())
            {
                Type t = (Type)typeof(Present).GetField("_contains", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(present);
                Thing containedObject = Activator.CreateInstance(t, Editor.GetConstructorParameters(t)) as Thing;

                Sprite _containedSprite = containedObject.graphic;
                _containedSprite.alpha = Floats["XrayAlpha"];
                _containedSprite.CenterOrigin();
                Graphics.Draw(_containedSprite, present.x, present.y);
            }

            foreach (ItemBox box in AvailableThings<ItemBox>())
            {
                if (box is not PurpleBlock && box.containedObject != null)
                {
                    Sprite _containedSprite = box.containedObject.graphic;
                    _containedSprite.alpha = Floats["XrayAlpha"];
                    _containedSprite.CenterOrigin();
                    Graphics.Draw(_containedSprite, box.x, box.y);
                }
            }

            StopDraw(_layer);
        }
    }
}