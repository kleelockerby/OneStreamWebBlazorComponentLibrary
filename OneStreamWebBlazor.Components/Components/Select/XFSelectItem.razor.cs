using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFSelectItem<TValue> : XFComponentBase
    {
        [CascadingParameter] protected XFSelect<TValue> ParentSelect { get; set; }
        [Parameter] public TValue Value { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected bool Selected => ParentSelect?.ContainsValue(Value) == true;

        protected string StringValue => Value?.ToString();

    }
}