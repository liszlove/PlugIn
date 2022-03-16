using PlugIn.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginB
{

    public class PluginB : IBasePlugin
    {
        private static PluginB _instance;

        public static PluginB Instance
        {
            get => _instance;
        }

        public (uint, string) Dispose()
        {
            return ((IBasePlugin)Instance).Dispose();
        }

        public (uint, string) Load()
        {
            return (0, "PluginB Load");
        }
    }
}
