using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Helpers;
using OneStreamWebBlazor.Components.Common;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFListBoxItem<TItem> : XFComponentBase
    {
        private bool _isSelected = false;

        [Parameter] public string Text { get; set; }
        [Parameter] public string Value { get; set; }
        [Parameter] public TItem DataItem { get; set; }
        
        [Parameter] public Action<TItem, XFListBoxItem<TItem>> SelectedListBoxItemChanged { get; set; }
        [Parameter] public bool IsSelected { get => _isSelected; set => _isSelected = value; }
        [Parameter] public int ListItemHeight { get; set; } = 27;

        [Parameter] public RenderFragment ItemTemplate { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected void OnClickHandler()
        {
            _isSelected = !_isSelected;
            this.OnChangeHandler();
        }

        protected override void OnInitialized()
        {
            if(this.IsSelected == true)
            {
                this.OnChangeHandler();
            }
        }

        public void OnChangeHandler()
        {
            SelectedListBoxItemChanged?.Invoke(DataItem, this);
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.ListBoxItem(_isSelected));
            base.BuildClasses(builder);
        }

        protected override void BuildStyles(StyleBuilder builder)
        {
            builder.Append(StyleProvider.ListItemHeight(ListItemHeight));
            builder.Append(StyleProvider.ListItemTemplate(this.ItemTemplate != null));
            base.BuildStyles(builder);
        }
    }
}