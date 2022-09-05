using DuckGame;
using System.Reflection;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;

namespace EsportGraphics.src.EGraphics
{
    internal class Bullets : UpdateAndDraw
    {
        private Layer _layer = Layer.Foreground;
        public override void Draw()
        {
            StartDraw(_layer);

            //foreach (Bullet bullet in Level.current.things[typeof(Bullet)])
            //{
            //    Graphics.DrawLine(p1: bullet.end,
            //                      p2: bullet.start,
            //                      col: Color.Red * 0.5f);

            //}

            StopDraw(_layer);
        }
        public override void Update()
        {
            foreach (Bullet bullet in Level.current.things[typeof(Bullet)])
            {
                if (bullet == null)
                    return;


                if (bullet.owner != null && bullet.owner.isLocal && bullet is not GrenadeBullet)
                {
                    bullet.color = Color.Green;
                }
                else
                    bullet.color = Color.Red;
            }
        }
    }
}
