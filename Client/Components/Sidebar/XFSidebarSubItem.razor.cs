using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;
using OneStreamWebBlazor.Client.Models;
using OneStreamWebBlazor.Shared;
using OneStreamWebBlazor.Components.Components;

namespace OneStreamWebBlazor.Client.Components.Sidebar
{
    public partial class XFSidebarSubItem : XFComponentBase
    {
        [CascadingParameter] protected Task<AuthenticationState> authenticationState { get; set; }
        [Inject] protected HttpClient Http { get; set; }
        [Parameter] public Guid? Id { get; set; }
        [Parameter] public string IconClassNames { get; set; } = null;
        [Parameter] public string Title { get; set; }
        [Parameter] public XFSidebarItemType SidebarItemType { get; set; }

        private string _anchorClassNames;
        [Parameter]
        public string AnchorClassNames
        {
            get { return _anchorClassNames; }
            set { _anchorClassNames = value; }
        }

        protected List<SidebarItemData> ItemsData = new List<SidebarItemData>();

        protected string ULClasses = "submenu";
        protected bool IsOpen { get; set; } = false;

        protected string UlClassNames
        {
            get
            {
                var cssString = ULClasses;
                cssString += IsOpen ? " open" : "";
                return cssString.Trim();
            }
        }

        protected string AnchorClasses
        {
            get
            {
                var cssString = _anchorClassNames;
                cssString += IsOpen ? " special" : "";
                return cssString.Trim();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (SidebarItemType == XFSidebarItemType.CubeView)
            {
                await this.GetCubeViewsInProfileAsync(this.Id);
            }
            else if (SidebarItemType == XFSidebarItemType.Dashboard)
            {
                await this.GetDashboardsInProfileAsync(this.Id);
            }
        }

        public async Task GetCubeViewsInProfileAsync(Guid? Id)
        {
            var userState = authenticationState.Result;
            string claimSI = userState?.User?.FindFirst("SI")?.Value;

            if (!string.IsNullOrEmpty(claimSI))
            {
                SessionInfo si = JsonConvert.DeserializeObject<SessionInfo>(claimSI);
                if ((si != null) && (si.IsAuthenticated))
                {
                    XFGuidRequestDto guidDto = new XFGuidRequestDto(si, (Guid)Id);
                    HttpResponseMessage responseMessage = await Http.PostAsJsonAsync<XFGuidRequestDto>("api/internal/dashboards/GetCubeViewsInProfile", guidDto);
                    List<CubeViewItemSummaryInfo> cubeViews = await responseMessage?.Content?.ReadFromJsonAsync<List<CubeViewItemSummaryInfo>>();

                    foreach (CubeViewItemSummaryInfo cubeView in cubeViews)
                    {
                        ItemsData.Add(new SidebarItemData(cubeView.NameOrDescription, "xfChild xf-CubeView-flyout", XFSidebarItemType.CubeView, cubeView.UniqueID, "flyout-indent", $"cubeviews/{cubeView.UniqueID}"));
                    }
                    StateHasChanged();
                }

            }
        }

        public async Task GetDashboardsInProfileAsync(Guid? Id)
        {
            var userState = authenticationState.Result;
            string claimSI = userState?.User?.FindFirst("SI")?.Value;

            

            if (!string.IsNullOrEmpty(claimSI))
            {
                SessionInfo si = JsonConvert.DeserializeObject<SessionInfo>(claimSI);

                if ((si != null) && (si.IsAuthenticated))
                {
                    XFGuidRequestDto guidDto = new XFGuidRequestDto(si, (Guid)Id);
                    HttpResponseMessage responseMessage = await Http.PostAsJsonAsync<XFGuidRequestDto>("api/internal/dashboards/GetDashboardsInProfile", guidDto);
                    List<Dashboard> dashboards = await responseMessage?.Content?.ReadFromJsonAsync<List<Dashboard>>();

                    foreach (Dashboard dashboard in dashboards)
                    {
                        ItemsData.Add(new SidebarItemData(dashboard.NameOrDescription, "xfChild xf-Dashboard-flyout", XFSidebarItemType.Dashboard, dashboard.UniqueID, "flyout-indent", $"dashboards/{dashboard.UniqueID}/{dashboard.Name}"));
                    }
                    StateHasChanged();
                }
            }
        }

        protected void ToggleMenu()
        {
            IsOpen = !IsOpen;
            StateHasChanged();
        }

    }
}
