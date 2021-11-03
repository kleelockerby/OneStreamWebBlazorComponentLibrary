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
    public class XFListBoxBase<TItem> : XFComponentBase
    {
        private IEnumerable<TItem> _dataSource;
        private List<TItem> _dataSourceView = new List<TItem>();
 
        protected bool visible = false;
        private bool allowFiltering = true;
        private bool allowTextEntry = false;
        protected string SelectedText = string.Empty;
        protected string SelectedChars = string.Empty;
        protected object SelectedValue = null;

        protected XFListBoxItem<TItem> SelectedListBoxItem = null;

        [Parameter] public Func<TItem, string> TextField { get; set; }
        [Parameter] public Func<TItem, object> ValueField { get; set; }

        [Parameter] public TItem SelectedItem { get; set; }
        [Parameter] public Action<TItem> SelectedItemChanged { get; set; }
        [Parameter] public Action<object> SelectedValueChanged { get; set; }

        [Parameter] public FilterCaseSensitivity FilterCaseSensitivity { get; set; } = FilterCaseSensitivity.CaseInsensitive;
        [Parameter] public SearchFilterMode FilterMode { get; set; } = SearchFilterMode.StartsWith;
        [Parameter] public int NoDisplayItems { get; set; } = 5;
        [Parameter] public int ListItemHeight { get; set; } = 30;
        [Parameter] public bool IgnoreCase { get; set; } = true;
        [Parameter] public bool AllowFiltering
        { 
            get { return allowFiltering; }
            set 
            {
                allowFiltering = value;
                allowTextEntry = (allowFiltering == true) ? false : true;
            }
        }
        [Parameter] public bool AllowTextEntry 
        { 
            get { return allowTextEntry; }
            set
            {
                allowTextEntry = value;
                allowFiltering = (allowTextEntry == true) ? false : true;
            }
        }

        protected IQueryable<TItem> Query { get { return this._dataSource.AsQueryable(); } }

        [Parameter]
        public IEnumerable<TItem> DataSource
        {
            get { return this._dataSource; }
            set { this._dataSource = value; }
        }

        protected List<TItem> DataSourceView
        {
            get { return this._dataSourceView; }
        }

        protected int ListBoxHeight
        {
            get
            {
                var h = (this.ListItemHeight * this.NoDisplayItems) + 2;   //($listItemHeight * $listBoxNoItemsDisplay) + $listBoxBorderTopWidth + $listBoxBorderBottomWidth;
                return h;
            }
        }

        protected override void OnInitialized()
        {
            this._dataSourceView = this.DataSource.ToList();

            if(this.SelectedItem != null)
            {
                this.SelectedText = TextField?.Invoke(this.SelectedItem);
            }
        }

        protected void ListBox_ItemChanged(TItem item, XFListBoxItem<TItem> listBoxItem)
        {
            if (this.SelectedListBoxItem != null)
            {
                this.SelectedListBoxItem.IsSelected = false;
            }
            this.SelectedListBoxItem = listBoxItem;
            this.SelectedItem = item;
            this.SelectedText = TextField?.Invoke(item);
            this.SelectedValue = ValueField?.Invoke(item);
            this.SelectedItemChanged.Invoke(item);
            //this.Toggle();
            this.Hide();
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

        protected void FilterData(IQueryable<TItem> query)
        {
            if(this._dataSourceView != null)
            {
                this._dataSourceView.Clear();
            }

            if (this.FilterMode == SearchFilterMode.StartsWith)
            {
                if(this.FilterCaseSensitivity == FilterCaseSensitivity.CaseInsensitive)
                    query = query.Select(fil => new { fil, text = TextField.Invoke(fil) }).Where(x => x.text.StartsWith(SelectedChars, StringComparison.OrdinalIgnoreCase)).OrderBy(y => y.text).Select(z => z.fil);
                else
                    query = query.Select(fil => new { fil, text = TextField.Invoke(fil) }).Where(x => x.text.StartsWith(SelectedChars)).OrderBy(y => y.text).Select(z => z.fil);
            }
            else
            {
                if (this.FilterCaseSensitivity == FilterCaseSensitivity.CaseInsensitive)
                    query = query.Select(fil => new { fil, text = TextField.Invoke(fil) }).Where(x => x.text.IndexOf(SelectedChars, 0, StringComparison.OrdinalIgnoreCase) > 0).OrderBy(y => y.text).Select(z => z.fil);
                else
                    query = query.Select(fil => new { fil, text = TextField.Invoke(fil) }).Where(x => x.text.IndexOf(SelectedChars, 0) > 0).OrderBy(y => y.text).Select(z => z.fil);
            }

            this._dataSourceView = query.ToList();
        }
    }
}