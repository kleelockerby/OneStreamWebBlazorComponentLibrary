using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Helpers;
using OneStreamWebBlazor.Components.Common;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFListBox<TItem> : XFComponentBase
    {
        private bool visible = false;
        private XFListBoxItem<TItem> SelectedListBoxItem = null;

        [CascadingParameter] protected XFComboBox<TItem> ComboBox { get; set; }

        //[Parameter] public IEnumerable<TItem> DataSource { get; set; }
        [Parameter] public Func<TItem, string> TextField { get; set; }
        [Parameter] public Func<TItem, object> ValueField { get; set; }

        [Parameter] public TItem SelectedItem { get; set; }
        [Parameter] public EventCallback<TItem> SelectedItemChanged { get; set; }

        protected ClassBuilder ContentClassBuilder { get; private set; }
        protected string ContentClassNames => ContentClassBuilder.Class;

        protected List<TItem> DataSource { get; set; }

        public XFListBox()
        {
            ContentClassBuilder = new ClassBuilder(BuildContentClasses);
        }

        protected override void OnInitialized()
        {
            this.DataSource = ComboBox.DataSource.ToList();
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.ListBox() );
            builder.Append(" show", visible);
            base.BuildClasses(builder);
        }

        private void BuildContentClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.ListBoxContent());
        }

        protected void XFListBoxItem_Changed(TItem item, XFListBoxItem<TItem> listBoxItem)
         {
            if (this.SelectedListBoxItem != null)
            {
                this.SelectedListBoxItem.IsSelected = false;
            }
            this.SelectedListBoxItem = listBoxItem;
            this.SelectedItem = item;
            SelectedItemChanged.InvokeAsync(item);
         }

        public void Toggle()
        {
            this.visible = !this.visible;
            StateHasChanged();
        }

        public void Hide()
        {
            this.visible = false;
            StateHasChanged();
        }

        public void Show()
        {
            this.visible = true;
            StateHasChanged();
        }



    }
}





/*



        protected async Task XFListBoxItem_Changed(ListBoxItemChangedEventArgs e)
        {
            if (this.SelectedListBoxItem != null)
            {
                this.SelectedListBoxItem.IsSelected = false;
            }
            this.SelectedListBoxItem = e.ListBoxItem;
        }




*/
