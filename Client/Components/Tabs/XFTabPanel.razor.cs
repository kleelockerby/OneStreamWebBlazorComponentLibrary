using System;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Client.Utilities;
using OneStreamWebBlazor.Components.Components;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Client.Components.Tabs
{
    public partial class XFTabPanel : XFComponentBase, IDisposable
    {
        [CascadingParameter] protected XFTabControl TabControl { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Name { get; set; }

        private bool IsActive;

        protected override void OnInitialized()
        {
            if (this.TabControl != null)
            {
                this.TabControl.AddTabPanel(Name);
                this.IsActive = Name == this.TabControl.SelectedTab;
                this.TabControl.StateChanged += OnTabsContentStateChanged;
            }
            base.OnInitialized();
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.TabPanel() );
            builder.Append("active", IsActive);
            base.BuildClasses(builder);
        }

        private void OnTabsContentStateChanged(object sender, XFTabsStateEventArgs e)
        {
            this.IsActive = this.Name == e.TabName;
        }

        private void OnTabsContentStateChanged(object sender, XFTabsContentStateEventArgs e)
        {
            this.IsActive = this.Name == e.PanelName;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.TabControl != null)
                {
                    this.TabControl.StateChanged -= OnTabsContentStateChanged;
                }
            }
            base.Dispose(disposing);
        }
    }
}