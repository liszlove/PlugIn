using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugIn.Core
{
    public interface IBasePlugin
    {
        (uint, string) Load();
        (uint, string) Dispose();
    }
}
