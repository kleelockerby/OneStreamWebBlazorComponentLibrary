using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneStreamWebBlazor.Client.Models
{
    public class TabItemData
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string IconClasses { get; set; }
        public string PanelText { get; set; }

        public TabItemData() { }
        public TabItemData(string name, string title, string iconClasses, string panelText)
        {
            this.Name = name;
            this.Title = title;
            this.IconClasses = iconClasses;
            this.PanelText = panelText;
        }
    }
}
