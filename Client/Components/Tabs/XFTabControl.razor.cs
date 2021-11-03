using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Client.Utilities;
using OneStreamWebBlazor.Components.Components;
using OneStreamWebBlazor.Components.Common;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Client.Components.Tabs
{
    public partial class XFTabControl : XFComponentBase
    {
        private bool pills;
        private bool fullWidth;
        private bool justified;
        private string selectedTab;
        private TabPosition tabPosition = TabPosition.Top;
        private List<string> tabItems = new List<string>();
        private List<string> tabPanels = new List<string>();
        protected int IndexOfSelectedTab => tabItems.IndexOf(selectedTab);
        protected IReadOnlyList<string> TabItems => tabItems;
        protected IReadOnlyList<string> TabPanels => tabPanels;
        public event EventHandler<XFTabsStateEventArgs> StateChanged;

        //protected bool IsCards => CardHeader != null;
        protected ClassBuilder ContentClassBuilder { get; private set; }
        protected string ContentClassNames => ContentClassBuilder.Class;

        [Parameter] public RenderFragment Items { get; set; }
        [Parameter] public RenderFragment Content { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback<string> SelectedTabChanged { get; set; }
        //[CascadingParameter] protected CardHeader CardHeader { get; set; }

        [Parameter]
        public bool Pills
        {
            get => pills;
            set => pills = value;
        }

        [Parameter]
        public bool FullWidth
        {
            get => fullWidth;
            set => fullWidth = value;
        }

        [Parameter]
        public bool Justified
        {
            get => justified;
            set => justified = value;
        }

        [Parameter]
        public TabPosition TabPosition
        {
            get => tabPosition;
            set => tabPosition = value;
        }

        [Parameter]
        public string SelectedTab
        {
            get => selectedTab;
            set
            {
                if (value == selectedTab)          // prevent tabs from calling the same code multiple times
                    return;

                selectedTab = value;
                StateChanged?.Invoke(this, new XFTabsStateEventArgs(selectedTab));
                SelectedTabChanged.InvokeAsync(selectedTab);
            }
        }

        public XFTabControl()
        {
            ContentClassBuilder = new ClassBuilder(BuildContentClasses);
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append( ClassProvider.Tabs() );
            //builder.Append(ClassProvider.TabsCards(), IsCards);
            builder.Append(ClassProvider.TabsPills(), Pills);
            builder.Append(ClassProvider.TabsFullWidth(), FullWidth);
            builder.Append(ClassProvider.TabsJustified(), Justified);
            builder.Append(ClassProvider.TabsVertical(), TabPosition == TabPosition.Left || TabPosition == TabPosition.Right);
            base.BuildClasses(builder);
        }

        private void BuildContentClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.TabsContent());
        }

        public void SelectTab(string tabName)
        {
            this.SelectedTab = tabName;
            StateHasChanged();
        }

        internal void AddTab(string tabName)
        {
            this.tabItems.Add(tabName);
        }

        internal void AddTabPanel(string panelName)
        {
            this.tabPanels.Add(panelName);
        }

    }
}