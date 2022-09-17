using DuckGame;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;
using static Config.ESConfig;

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

            foreach (Ragdoll ragdoll in AvailableThings<Ragdoll>())
            {
                if (ragdoll._duck != null)
                { 
                    if (!ragdoll._duck.isLocal && !ragdoll._duck.dead)
                    {
                        ragdoll.part1.material = new Shaders.ColorMaterial(ESColors["EnemyDuck"], true);
                        ragdoll.part2.material = new Shaders.ColorMaterial(ESColors["EnemyDuck"], true);
                        ragdoll.part3.material = new Shaders.ColorMaterial(ESColors["EnemyDuck"], true);
                    }
                    else if (ragdoll._duck.dead)
                    {
                        ragdoll.part1.material = new Shaders.ColorMaterial(ESColors["Back"], true);
                        ragdoll.part2.material = new Shaders.ColorMaterial(ESColors["Back"], true);
                        ragdoll.part3.material = new Shaders.ColorMaterial(ESColors["Back"], true);
                    }
                }
            }
        }
    }
}
