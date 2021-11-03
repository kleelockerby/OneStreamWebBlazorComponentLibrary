using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneStreamWebBlazor.Client.Components.Sidebar;

namespace OneStreamWebBlazor.Client.Models
{
    public class SidebarItemData
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string IconClassNames { get; set; }
        public string AnchorClassNames { get; set; }
        public string To { get; set; }
        public XFSidebarItemType SidebarItemType { get; set; }

        public SidebarItemData() { }

        public SidebarItemData(string title, string iconClassNames, XFSidebarItemType sidebarItemType)
        {
            this.Title = title;
            this.IconClassNames = iconClassNames;
            this.SidebarItemType = sidebarItemType;
        }

        public SidebarItemData(string title, string iconClassNames, XFSidebarItemType sidebarItemType, Guid? id, string anchorClassNames, string to)
        {
            this.Title = title;
            this.IconClassNames = iconClassNames;
            this.SidebarItemType = sidebarItemType;
            this.Id = id;
            this.AnchorClassNames = anchorClassNames;
            this.To = to;
        }
    }
}
