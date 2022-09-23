using DuckGame;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;
using static Config.ESConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.EGraphics
{
    internal class DrawRange : UpdateAndDraw
    {
        private Layer _layer = Layer.Foreground;
        public override void Draw()
        {
            if (!Settings["Range"])
                return;

            StartDraw(_layer);

            try
            {
                Duck localDuck = DuckNetwork.localProfile.duck;

                if (localDuck != null && localDuck.holdObject != null && localDuck.holdObject is Gun)
                {
                    HandleGun(localDuck.holdObject as Gun);
                }

            }
            catch (Exception) { }

            StopDraw(_layer);
        }
        private void HandleGun(Gun gun)
        {
            try
            {
                Vec2 position = gun.position;
                float height = 22f;
                float rawAngle = gun.angle;
                float radius = (gun.ammoType != null)? gun.ammoType.range + 20 : 1000f;
                float offDir = gun.offDir;

                float halfDuckAngle = (float)Math.Atan2(height/2, radius);

                float plusAngle = rawAngle + halfDuckAngle;
                float minusAngle = rawAngle - halfDuckAngle;

                Vec2 point1 = GetPositionFromAngle(position, plusAngle, radius, offDir);
                Vec2 point2 = GetPositionFromAngle(position, minusAngle, radius, offDir);
                Vec2 centeredPoint = GetPositionFromAngle(position, rawAngle, radius, offDir);

                Graphics.DrawLine(point1, point2, ESColors["Range"]);

                if (Settings["RangeLaser"])
                    Graphics.DrawLine(position, centeredPoint, ESColors["RangeLaser"]);
            }
            catch(Exception) { }
        }
        private Vec2 GetPositionFromAngle(Vec2 center, float angle, float radius, float offDir)
        {
            float pointX = (float)(radius * Math.Cos((double)angle));
            float pointY = (float)(radius * Math.Sin((double)angle));

            return new Vec2(center.x + pointX * offDir, center.y + pointY * offDir);
        }
    }
}
