using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ModName.src.Core;

namespace ModName.src
{
    static class ModInitialize
    {
        public static void PreInitialize()
        {

        }
        public static void PostInitialize()
        {
            InitializeDraws();
            InitializeUpdates();
        }
        private static void InitializeDraws()
        {
            IEnumerable<Type> drawList = Assembly.GetAssembly(typeof(DrawMe)).GetTypes().Where(type => type.IsSubclassOf(typeof(DrawMe)));

            foreach (Type drawItem in drawList) { DrawMe instance = (DrawMe)Activator.CreateInstance(drawItem); }
        }
        private static void InitializeUpdates()
        {
            IEnumerable<Type> updateList = Assembly.GetAssembly(typeof(UpdateMe)).GetTypes().Where(type => type.IsSubclassOf(typeof(UpdateMe)));

            foreach (Type updateItem in updateList) { UpdateMe instance = (UpdateMe)Activator.CreateInstance(updateItem); }
        }
    }
}
