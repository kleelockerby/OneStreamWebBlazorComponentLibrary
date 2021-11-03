using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;
using OneStreamWebBlazor.Client.Models;
using OneStreamWebBlazor.Shared;
using OneStreamWebBlazor.Components.Components;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Client.Components.Sidebar
{
    public partial class XFSidebar : XFComponentBase
    {
        [CascadingParameter] protected Task<AuthenticationState> authenticationState { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string HeaderText { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append("xf-sidebar");
            base.BuildClasses(builder);
        }

    }
}
