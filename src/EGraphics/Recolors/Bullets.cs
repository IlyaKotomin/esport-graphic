using DuckGame;
using static Config.ESConfig;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;

namespace EsportGraphics.src.EGraphics.Recolors
{
    internal class Bullets : UpdateAndDraw
    {
        private Layer _layer = Layer.Foreground;
        public override void Draw()
        {
            StartDraw(_layer);

            if(Settings["Bullets"])
                foreach (Net net in Level.current.things[typeof(Net)])
                    Graphics.DrawRect(net.topLeft, net.bottomRight, ESColors["EnemyBullet"]);

            StopDraw(_layer);
        }
        public override void Update()
        {
            if (!Settings["Bullets"])
                return;

            foreach (Bullet bullet in AvailableThings<Bullet>())
            {
                if (bullet == null)
                    return;

                if (bullet.owner != null && bullet.owner.isLocal && bullet is not GrenadeBullet)
                {
                    bullet.color = ESColors["LocalBullet"];
                }
                else
                    bullet.color = ESColors["EnemyBullet"];
            }
        }
    }
}
