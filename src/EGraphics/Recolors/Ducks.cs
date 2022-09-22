using DuckGame;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;
using static Config.ESConfig;
using System.Linq;

namespace EsportGraphics.src.EGraphics.Recolors
{
    internal class Ducks : UpdateAndDraw
    {
        private Layer _layer = Layer.Foreground;
        public override void Draw()
        {
            StartDraw(_layer);


            StopDraw(_layer);
        }
        public override void Update()
        {
            if (!Settings["Ducks"])
                return;

            foreach (Duck duck in AvailableThings<Duck>())
                if (!duck.isLocal)
                    duck.blendColor = ESColors["EnemyDuck"];

            foreach (var ragdoll in from Ragdoll ragdoll in AvailableThings<Ragdoll>()
                                    where ragdoll._duck != null
                                    select ragdoll)
            {
                if (!ragdoll._duck.isLocal && !ragdoll._duck.dead)
                {
                    ragdoll.part1.material = new Shaders.ColorMaterial(ESColors["EnemyDuck"]);
                    ragdoll.part2.material = new Shaders.ColorMaterial(ESColors["EnemyDuck"]);
                    ragdoll.part3.material = new Shaders.ColorMaterial(ESColors["EnemyDuck"]);
                }
                else if (ragdoll._duck.dead)
                {
                    ragdoll.part1.material = new Shaders.ColorMaterial(ESColors["Back"]);
                    ragdoll.part2.material = new Shaders.ColorMaterial(ESColors["Back"]);
                    ragdoll.part3.material = new Shaders.ColorMaterial(ESColors["Back"]);
                }
            }
        }
    }
}
