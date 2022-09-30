using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPanelStart.Entites
{
    public class AddInDataForServer
    {
        public string RevitVersion { get; set; }
        public string PluginName { get; set; }
        public string UserName { get; set; }
        public string DateCreate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    }
}
