using DuckGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.Core
{
    public static class DependencyResolver
    {
        public static void ResolveDependencies()
        {
            AppDomain.CurrentDomain.AssemblyResolve += Resolve;
        }
        private static Assembly Resolve(object sender, ResolveEventArgs args)
        {

            string assemblyFullName = args.Name;
            string assemblyShortName = assemblyFullName;

            try
            {
                assemblyShortName = assemblyFullName.Substring(0, assemblyFullName.IndexOf(",", StringComparison.Ordinal));
            }
            catch (Exception)
            {

            }

            if (Assembly.GetCallingAssembly() != Assembly.GetExecutingAssembly())
            {
                return null;
            }

            try
            {
                var assembly = AppDomain.CurrentDomain.GetAssemblies().First(x => x.FullName == assemblyFullName);

                if (!(assembly is null))
                {
                    return assembly;
                }
            }
            catch (InvalidOperationException)
            {
            }

            string path = Mod.GetPath<DuckGame.src.EsportGraphicsMod>("/dlls/" + assemblyShortName + ".dll");

            if (!File.Exists(path))
            {
                return null;
            }

            Assembly loadedAssembly = null;

            try
            {
                loadedAssembly = Assembly.LoadFrom(path);
            }
            catch (Exception)
            {
                try
                {
                    loadedAssembly = Assembly.Load(File.ReadAllBytes(path));
                }
                catch (Exception)
                {

                }
            }
            return loadedAssembly;

        }
    }
}
