using static EsportGraphics.src.Core.Utilites;
using DuckGame;
using EsportGraphics.src.Core;

namespace EsportGraphics.src.EGraphics
{
    internal class Background : UpdateAndDraw
    {
        private Layer _layer = Layer.Foreground;
        public override void Draw()
        {
        }
        public override void Update()
        {
            if (Level.current.backgroundColor != Color.Black)
                Level.current.backgroundColor = Color.Black;

            foreach (Thing t in Level.current.things)
                if (t is not Block && t is not SmallFire && t is not ExplosionPart && t is not IPlatform && t is not Fluid && t is not Spikes && t is not Spring && t is not PhysicsObject && t is not Bullet && t is not QuadLaserBullet)
                    t.material = new Shaders.ColorMaterial(ESColors.BackColor, true);
        }
    }
}
