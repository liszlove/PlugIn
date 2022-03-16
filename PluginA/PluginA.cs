using PlugIn.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginA
{

    public class PluginA : IBasePlugin
    {
        private static PluginA _instance;

        public static PluginA Instance
        {
            get => _instance;
        }

        public (uint, string) Dispose()
        {
            return ((IBasePlugin)Instance).Dispose();
        }

        public (uint, string) Load()
        {
            return (0, "PluginA Load");
        }
    }
}
