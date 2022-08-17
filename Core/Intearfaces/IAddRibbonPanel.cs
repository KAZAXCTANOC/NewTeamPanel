using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPanelStart.Core.Intearfaces
{
    public interface IAddRibbonPanel
    {
        void AddButtonBitmap(RibbonPanel panel, string PathToDirectory, string NameOfTheExecutableClass, string Header, string toolTip, Bitmap img);
    }
}
