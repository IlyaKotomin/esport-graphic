using DuckGame;
using static Config.ESConfig;
using static EsportGraphics.src.Core.Utilites;
using EsportGraphics.src.Core;

namespace EsportGraphics.src.EGraphics.Timers
{
    internal class ItemBoxesPB : UpdateAndDraw
    {
        private Layer _layer = Layer.Game;
        public override void Draw()
        {
            if (!Settings["ItemBoxBar"])
                return;

            StartDraw(_layer);

            foreach (ItemBox itemBox in AvailableThings<ItemBox>())
                if(itemBox is not PurpleBlock)
                    ESProgressBars.DrawLineBar(
                        itemBox.bottomLeft,
                        itemBox.bottomRight.x - itemBox.bottomLeft.x,
                        1f - ((float)itemBox.charging / 500),
                        ESColors["BarFront"],
                        ESColors["BarBack"],
                        ESColors["BarOutLine"],
                        2);

            StopDraw(_layer);
        }
    }
}
