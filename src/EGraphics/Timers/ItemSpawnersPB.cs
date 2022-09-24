using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EsportGraphics.src.Core.Utilites;
using static Config.ESConfig;
using EsportGraphics.src.Core;
using DuckGame;

namespace EsportGraphics.src.EGraphics.Timers
{
    internal class ItemSpawnersPB : UpdateAndDraw
    {
        static Layer _layer = Layer.Game;
        public override void Draw()
        {
            if (!Settings["ItemSpawnerBar"] || DuckNetwork.hostProfile != DuckNetwork.localProfile)
                return;

            base.Draw();

            StartDraw(_layer);

            foreach (ItemSpawner spawner in AvailableThings<ItemSpawner>())
            {
                if (spawner.contains != null)
                {
                    float lengh = (spawner.bottomRight.x - spawner.bottomLeft.x);

                    ESProgressBars.DrawLineBar(spawner.bottomLeft,
                                               lengh,
                                               spawner._spawnWait / spawner.spawnTime,
                                               ESColors["BarFront"],
                                               ESColors["BarBack"],
                                               ESColors["BarOutLine"],
                                               2);
                }
            }
           
            StopDraw(_layer);
        }
    }
}
