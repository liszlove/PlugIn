using PlugIn.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlugIn.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> paths = FindPluginPaths();
            List<IBasePlugin> plugins = GetPlugins(paths);

            foreach (var plugin in plugins)
            {
                Console.WriteLine(plugin.Load());
            }

            Console.ReadKey();
        }

        private static List<string> FindPluginPaths()
        {
            List<string> paths = new List<string>();
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                path = Path.Combine(path, "Plugins");
                foreach (string fileName in Directory.GetFiles(path, "*.dll"))
                {
                    paths.Add(fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return paths;
        }

        private static List<IBasePlugin> GetPlugins(List<string> paths)
        {
            List<IBasePlugin> plugins = new List<IBasePlugin>();
            foreach (string pluginPath in paths)
            {
                try
                {
                    string asmName = Path.GetFileNameWithoutExtension(pluginPath);
                    if (asmName != string.Empty)
                    {
                        Assembly asm = Assembly.LoadFile(pluginPath);
                        Type[] types = asm.GetExportedTypes();
                        foreach (Type t in types)
                        {
                            if (t.GetInterface("IBasePlugin") != null)
                            {
                                IBasePlugin plugin = (IBasePlugin)Activator.CreateInstance(t);
                                plugins.Add(plugin);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return plugins;
        }
    }
}
