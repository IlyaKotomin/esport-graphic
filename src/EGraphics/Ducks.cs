using DuckGame;
using EsportGraphics.src.Core;
using static EsportGraphics.src.Core.Utilites;
using System.Reflection;
using System;

namespace EsportGraphics.src.EGraphics
{
    internal class Ducks : UpdateAndDraw
    {
        private Layer _layer = Layer.Foreground;
        public override void Draw()
        {
            StartDraw(_layer);
            
            foreach (Ragdoll ragdoll in AvailableThings<Ragdoll>())
            {
                if (ragdoll._duck != null)
                { 
                    if (!ragdoll._duck.isLocal && !ragdoll._duck.dead)
                    {
                        ragdoll.part1.material = new Shaders.ColorMaterial(ESColors.EnemyHitBoxes, true);
                        ragdoll.part2.material = new Shaders.ColorMaterial(ESColors.EnemyHitBoxes, true);
                        ragdoll.part3.material = new Shaders.ColorMaterial(ESColors.EnemyHitBoxes, true);
                    }
                    else if (ragdoll._duck.dead)
                    {
                        ragdoll.part1.material = new Shaders.ColorMaterial(ESColors.BackColor, true);
                        ragdoll.part2.material = new Shaders.ColorMaterial(ESColors.BackColor, true);
                        ragdoll.part3.material = new Shaders.ColorMaterial(ESColors.BackColor, true);
                    }
                }

            }

            StopDraw(_layer);
        }
        public override void Update()
        {
            foreach (Duck duck in AvailableThings<Duck>())
                if (!duck.isLocal)
                    duck.blendColor = ESColors.EnemyHitBoxes;

        }
    }
}
