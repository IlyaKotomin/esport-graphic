using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using DuckGame;
using EsportGraphics.src.Core;

namespace EsportGraphics.src
{
    static class ModInitialize
    {
        public static void PreInitialize()
        {
            DependencyResolver.ResolveDependencies();
            Config.Config.LoadAll();
        }
        public static void PostInitialize()
        {
            Config.ESOptions.Load();
            Shaders.ShaderLoader.Load();
            UpdateAndDraw.Initialize();
        }
        public static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            string name = "Microsoft.Xna.Framework.Content.Pipeline.dll";

            if (!args.Name.Contains(name))
                return null;

            return Assembly.LoadFrom(Mod.GetPath<DuckGame.src.EsportGraphicsMod>(name));
        }
    }
}
