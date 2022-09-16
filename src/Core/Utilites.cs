using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.Core
{
    internal static class Utilites
    {
        public static void StartDraw(Layer layer) => layer.Begin(true);
        public static void StopDraw(Layer layer) => layer.End(true);
        //public static IEnumerable<Thing> AvailableThings(Thing requestedThing) => Level.current.things[requestedThing.GetType()];
        //public static IEnumerable<Thing> AvailableThings(Type typeOfThing) => Level.current.things[typeOfThing];
        public static IEnumerable<Thing> AvailableThings<T>() => Level.current.things[typeof(T)];
        public static List<Duck> LocalDucks()
        {
            List<Duck> ducks = new List<Duck>();

            foreach (Profile profile in Profiles.active)
                if (profile.localPlayer && profile.duck != null)
                    ducks.Add(profile.duck);

            return ducks;
        }
    }
}
