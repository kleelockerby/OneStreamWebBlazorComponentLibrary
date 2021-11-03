using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Helpers;
using OneStreamWebBlazor.Components.Common;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFComboBox<TItem> : XFListBoxBase<TItem>
    {
        [Parameter] public string PlaceHolder { get; set; }
        [Parameter] public bool AllowClear { get; set; } = false;
        [Parameter] public RenderFragment<TItem> ItemTemplate { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected ClassBuilder ContentClassBuilder { get; private set; }
        protected string ContentClassNames => ContentClassBuilder.Class;

        protected ClassBuilder ListBoxClassBuilder { get; private set; }
        protected string ListBoxClassNames => ListBoxClassBuilder.Class;

        protected ClassBuilder ULClassBuilder { get; private set; }
        protected string ULClassNames => ULClassBuilder.Class;

        protected bool PreventDefault { get; private set; }
        protected bool StopPropogation { get; private set; }

        public XFComboBox()
        {
            ContentClassBuilder = new ClassBuilder(BuildContentClasses);
            ListBoxClassBuilder = new ClassBuilder(BuildListBoxClasses);
            ULClassBuilder = new ClassBuilder(BuildULClasses);
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.ComboBox());
            base.BuildClasses(builder);
        }

        private void BuildContentClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.ComboBoxWrapper() );
        }

        private void BuildListBoxClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.ListBox());
            builder.Append("show", visible);
        }

        private void BuildULClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.ListBoxContent());
        }

        protected void XFLink_Clicked()
        {
            this.Toggle();
        }

        protected void TextBox_InputChanged(string newChar)
        {
            if (!this.AllowFiltering)
                return;
            this.SelectedChars = newChar;
            this.FilterData(this.Query);
            StateHasChanged();
        }

        protected void TextBox_ValueChanged(string newText)
        {
            if (this.AllowTextEntry == false)
                return;
            this.SelectedText = newText;
            StateHasChanged();
        }

        protected void XFTextBox_Clicked()
        { 
            this.Show();
        }

        protected void BtnClose_Clicked()
        {
            this.Clear();
            this.Hide();
            StateHasChanged();
        }

        protected void Clear()
        {
            this.SelectedText = string.Empty;
            this.SelectedValue = null;

            if (this.SelectedListBoxItem != null)
            {
                this.SelectedListBoxItem.IsSelected = false;
                //this.SelectedListBoxItem.OnChangeHandler();
            }

            //this.SelectedValueChanged.Invoke(this.SelectedValue);
            //SearchChanged.InvokeAsync( CurrentSearch );
        }
    }
}






/*

 [Parameter] public IEnumerable<TItem> DataSource { get; set; }
        [Parameter] public Func<TItem, string> TextField { get; set; }
        [Parameter] public Func<TItem, object> ValueField { get; set; }

        [Parameter] public string TextFieldName { get; set; }
        [Parameter] public string ValueFieldName { get; set; }

        [Parameter] public TItem SelectedItem { get; set; }
        [Parameter] public Action<TItem> SelectedItemChanged { get; set; }
        [Parameter] public Action<object> SelectedValueChanged { get; set; }

        [Parameter] public SearchFilterMode FilterMode { get; set; } = SearchFilterMode.StartsWith;

        private List<TItem> filteredData = new List<TItem>();

        protected void Clear()
        {
            SelectedChars = null;
            ListBoxRef.Hide();

            SelectedText = string.Empty;
            this.SelectedValue = null;

            //this.SelectedValueChanged.Invoke(this.SelectedValue);
        }



        /*protected void OnListBoxItemChanged(TItem item)
        {
            this.SelectedItem = item;
            this.SelectedText = TextField?.Invoke(item);
            this.SelectedValue = ValueField?.Invoke(item);
            this.Toggle();     
        }






<XFListBox @ref = "ListBoxRef" TextField="@TextField" ValueField="@ValueField" SelectedItemChanged="@OnListBoxItemChanged" TItem="TItem"></XFListBox>

<div class="@ClassNames" style="@StyleNames" @attributes="@Attributes">
    <ul class="@ContentClassNames" style="height: 137px;" @attributes="@Attributes">
        @if(DataSource != null)
        {
            foreach (var item in DataSource)
            {
                string text = TextField?.Invoke(item);
                <XFListBoxItem Text = "@text" TItem = "TItem" DataItem = "item" SelectedItemChanged = "@XFListBoxItem_Changed" ></XFListBoxItem >
            }
        }

    </ul>
</div>



// [Parameter] public FilterCaseSensitivity FilterCaseSensitivity { get; set; }


              
  
        private void FilterData()
        {
            //filteredData.Clear();
            //StringComparison stringCompare = (FilterMode == SearchFilterMode.StartsWith) ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCultureIgnoreCase;
            //query = query.Select(fil => new { fil, text = TextField.Invoke(fil) }).Where(x => x.text.StartsWith(SelectedChars, stringCompare)).OrderBy(y => y.fil).Select(z => z.fil);
            //filteredData = query.ToList();

            var query = this.DataSource?.AsQueryable();

            query = from q in query
                    let text = TextField.Invoke(q)
                    where text.StartsWith(SelectedChars, StringComparison.OrdinalIgnoreCase)
                    select q;

            //Console.WriteLine(query.ToList<TItem>().Count());
          
        }

        

    query = from q in query
            let text = TextField.Invoke( q )
            where text.StartsWith( CurrentSearch, StringComparison.OrdinalIgnoreCase )
            select q;
   

filteredData = query.ToList();
             

 
 
 
 
 */


