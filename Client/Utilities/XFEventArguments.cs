using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneStreamWebBlazor.Client.Utilities
{
    public class DropdownStateEventArgs : EventArgs
    {
        public DropdownStateEventArgs(bool visible)
        {
            Visible = visible;
        }
        public bool Visible { get; }
    }

    public class XFTabsStateEventArgs : EventArgs
    {
        public string TabName { get; }
        public XFTabsStateEventArgs(string tabName)
        {
            TabName = tabName;
        }
    }

    public class XFTabsContentStateEventArgs : EventArgs
    {
        public string PanelName { get; }
        public XFTabsContentStateEventArgs(string panelName)
        {
            PanelName = panelName;
        }
    }

}
