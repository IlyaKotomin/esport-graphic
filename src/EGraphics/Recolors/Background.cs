using static EsportGraphics.src.Core.Utilites;
using DuckGame;
using EsportGraphics.src.Core;
using static Config.ESConfig;

namespace EsportGraphics.src.EGraphics.Recolors
{
    internal class Background : UpdateAndDraw
    {
        public override void Update()
        {
            if (!Settings["Back"])
                return;

            if (Level.current.backgroundColor != ESColors["Back"])
                Level.current.backgroundColor = ESColors["Back"];

            foreach (Thing t in Level.current.things)
                if (!IsParticle(t) && t is not GinormoBoard && t is not Block && t is not RagdollPart && t is not SmallFire && t is not DizzyStar && t is not ExplosionPart && t is not IPlatform && t is not Fluid && t is not Spring && t is not PhysicsObject && t is not Bullet && t is not QuadLaserBullet)
                    t.material = new Shaders.ColorMaterial(ESColors["Back"], true);
        }
        private static bool IsParticle(Thing obj)
        {
            if (obj is ConfettiParticle || obj is GlassParticle || obj is PhysicsParticle || obj is WaterParticle || obj is WagnusChargeParticle || obj is WagnusChargeParticle)
                return true;

            return false;
        }
    }
}
