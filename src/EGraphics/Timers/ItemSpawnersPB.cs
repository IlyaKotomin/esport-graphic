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
            if (!Settings["ItemSpawnerBar"])
                return;

            base.Draw();

            StartDraw(_layer);

            foreach (ItemSpawner spawner in AvailableThings<ItemSpawner>())
            {
                if (spawner.contains != null)
                {
                    float lengh = (spawner.bottomRight.x - spawner.bottomLeft.x);

                    ESProgressBars.DrawLineBar(spawner.topLeft,
                                               lengh,
                                               spawner._spawnWait / spawner.spawnTime,
                                               ESColors["BarFront"] * Floats["BarsAlpha"],
                                               ESColors["BarBack"] * Floats["BarsAlpha"],
                                               ESColors["BarOutLine"] * Floats["BarsAlpha"],
                                               2);
                }
            }
           
            StopDraw(_layer);
        }
    }
}
