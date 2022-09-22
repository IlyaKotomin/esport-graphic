using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;
using DuckGame;

namespace EsportGraphics.src.EGraphics
{
    internal class ESProgressBars
    {
		public static void DrawCircleBar(Vec2 pos, float radius, float percentages, Color color, float width = 1f, Depth depth = default(Depth), int iterations = 32)
		{
			Vec2 prev = Vec2.Zero;
            for (int i = 0; i < iterations; i++)
			{
				float val = Maths.DegToRad(360f / (float)(iterations - 1) * (float)i);
				Vec2 cur = new Vec2((float)Math.Sin((double)val) * radius, -(float)Math.Cos((double)val) * radius);
				if (i > 0)
				{
					Graphics.DrawLine(pos + cur, pos + prev, Color.Black, width, depth);
					if(((float)i / (float)iterations) <= percentages)
                    {
						Vec2 lineCenter = LineCenter(pos + cur, pos + prev, 2);
						Graphics.DrawLine(lineCenter, pos, color, width * 2, depth);
                    }
				}
				prev = cur;
			}
		}
		public static void DrawLineBar(Vec2 start, float lengh, float percentages,
			Color frontColor, Color backColor, Color outlineColor, float width = 1f, Depth depth = default(Depth))
        {
			Vec2 end = new Vec2(start.x + lengh, start.y);
			Vec2 boxTl = new Vec2(start.x - width, start.y - width);
			Vec2 boxBr = new Vec2(end.x + width, end.y + width);

			Graphics.DrawRect(boxTl, boxBr, outlineColor, depth, false, width);
			Graphics.DrawLine(start, end, backColor, width, depth + 1);

			Vec2 progressPos = new Vec2(start.x + (lengh * percentages), start.y);

            if  (progressPos.x > end.x)
				progressPos.x = end.x;

			Graphics.DrawLine(start, progressPos, frontColor, width, depth + 2);
		}
	}
}
