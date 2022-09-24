using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using DuckGame;
using EsportGraphics.src.Core;
using System.IO;

namespace EsportGraphics.src
{
    static class ModInitialize
    {
        public static void PreInitialize()
        {
            MonoMain.noIntro = true;


            //YEAH, I KNOW, THIS IS BULLSHIT, BUT MOD DOESNT WORK WITHOUT THIS!!!
            if (!File.Exists("Microsoft.Xna.Framework.Content.Pipeline.dll"))
                File.Copy(Mod.GetPath<DuckGame.src.EsportGraphicsMod>("/dlls/Microsoft.Xna.Framework.Content.Pipeline.dll"), "Microsoft.Xna.Framework.Content.Pipeline.dll");


            DependencyResolver.ResolveDependencies();
            Config.ESConfig.LoadAll();
        }
        public static void PostInitialize()
        {
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
