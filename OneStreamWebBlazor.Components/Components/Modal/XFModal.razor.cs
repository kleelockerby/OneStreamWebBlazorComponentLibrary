using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFModal : XFComponentBase
    {
        [Parameter] public RenderFragment HeaderTemplate { get; set; }
        [Parameter] public RenderFragment BodyTemplate { get; set; }
        [Parameter] public RenderFragment FooterTemplate { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        protected bool IsOpen { get; set; }

        protected string ClassName = "modal";

        protected string ModalClasses
        {
            get
            {
                var cssString = ClassName;
                cssString += IsOpen ? " open" : "";
                return cssString.Trim();
            }
        }

        public void HideModal()
        {
            IsOpen = !IsOpen;
            StateHasChanged();
        }

        public void ShowModal()
        {
            IsOpen = !IsOpen;
            StateHasChanged();
        }
    }
}