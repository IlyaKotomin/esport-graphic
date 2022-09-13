using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;
using DuckGame;

namespace EsportGraphics.src
{
    internal class EsportCamera : UpdateAndDraw
    {
        public override void Update()
        {
        //    Camera camera = new Camera();

        //    List<Vec2> positions = new List<Vec2>();

        //    foreach (Duck duck in AvailableThings(typeof(Duck)))
        //        positions.Add(duck.GetPos());

        //    if (positions.Count <= 1)
        //        return;

        //    if(Level.current.camera != camera)
        //        Level.current.camera = camera;

        //    Vec2 top = positions.OrderBy(pos => pos.y).LastOrDefault();
        //    Vec2 buttom = positions.OrderBy(pos => pos.y).FirstOrDefault();

        //    Vec2 left = positions.OrderBy(pos => pos.x).LastOrDefault();
        //    Vec2 right = positions.OrderBy(pos => pos.x).FirstOrDefault();

        //    Vec2 tl = new Vec2(left.x, top.y);
        //    Vec2 br = new Vec2(right.x, buttom.y);

        //    Vec2 center = new Vec2((tl.x + br.x) / 2, (tl.y + br.y) / 2);

        //    camera.center = center;


        }
        public override void Draw()
        {
            //StartDraw(Layer.Foreground);

            //Rectangle rect = new Rectangle();

            //List<Vec2> positions = new List<Vec2>();

            //foreach (Duck duck in AvailableThings(typeof(Duck)))
            //    positions.Add(duck.GetPos());

            //Vec2 top = positions.OrderBy(pos => pos.y).LastOrDefault();
            //Vec2 buttom = positions.OrderBy(pos => pos.y).FirstOrDefault();

            //Vec2 left = positions.OrderBy(pos => pos.x).LastOrDefault();
            //Vec2 right = positions.OrderBy(pos => pos.x).FirstOrDefault();

            //Vec2 tl = new Vec2(left.x, top.y);
            //Vec2 br = new Vec2(right.x, buttom.y);
            
            //Graphics.DrawRect(tl, br, Color.Red, filled: false);

            //StopDraw(Layer.Foreground);
        }
    }
}