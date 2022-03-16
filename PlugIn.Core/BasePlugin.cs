using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugIn.Core
{
    public abstract class BasePlugin : IBasePlugin
    {
        protected BasePlugin(string moduleType)
        {
            // TODO: Module registers in plugin.

        }

        public abstract (uint, string) Dispose();
        public abstract (uint, string) Load();
    }
}
