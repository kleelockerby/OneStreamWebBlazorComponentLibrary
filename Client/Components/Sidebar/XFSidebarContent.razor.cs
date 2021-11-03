using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Components;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Client.Components.Sidebar
{
    public partial class XFSidebarContent : XFComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append("xf-sidebar-nav");
            base.BuildClasses(builder);
        }
    }
}