using System;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Client.Utilities;
using OneStreamWebBlazor.Components.Components;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Client.Components.Tabs
{
    public partial class XFTab : XFComponentBase, IDisposable
    {
        [CascadingParameter] protected XFTabControl TabControl { get; set; }
        [Parameter] public string Name { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public string IconClasses { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public Action Clicked { get; set; }

        public string AnchorClasses  = "nav-link dashboard";
        private bool IsActive;
        
        protected ClassBuilder AnchorClassBuilder { get; private set; }
        protected string AnchorClassNames => AnchorClassBuilder.Class;

        protected ClassBuilder IconClassBuilder { get; private set; }
        protected string IconClassNames => IconClassBuilder.Class;

        public XFTab()
        {
            AnchorClassBuilder = new ClassBuilder(BuildAnchorClasses);
            IconClassBuilder = new ClassBuilder(BuildIconClasses);
        }

        protected override void OnInitialized()
        {
            if(this.TabControl != null)
            {
                this.TabControl.AddTab(Name);
                this.IsActive = Name == this.TabControl.SelectedTab;
                this.TabControl.StateChanged += OnTabsStateChanged;
            }
            base.OnInitialized();
        }

        private void OnTabsStateChanged(object sender, XFTabsStateEventArgs e)
        {
            this.IsActive = this.Name == e.TabName;
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append( ClassProvider.TabItem() );
            base.BuildClasses(builder);
        }

        private void BuildAnchorClasses(ClassBuilder builder)
        {
            builder.Append( ClassProvider.TabLink() );
            builder.Append("dashboard");
            builder.Append("active", IsActive);
        }

        private void BuildIconClasses(ClassBuilder builder)
        {
            builder.Append(IconClasses);
            builder.Append("mr-1");
        }

        protected void ClickHandler()
        {
            Clicked?.Invoke();
            this.TabControl?.SelectTab(Name);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.TabControl != null)
                {
                    this.TabControl.StateChanged -= OnTabsStateChanged;
                }
            }

            base.Dispose(disposing);
        }
    }
}