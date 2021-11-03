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
using OneStreamWebBlazor.Components.Components;
using OneStreamWebBlazor.Client.Models;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Client.Components.Sidebar
{
    public partial class XFSidebarItem : XFComponentBase
    {
        [CascadingParameter] protected Task<AuthenticationState> authenticationState { get; set; }
        [Inject] protected HttpClient Http { get; set; }
        [Parameter] public string Id { get; set; }
        [Parameter] public string AnchorClassNames { get; set; }
        [Parameter] public string IconClassNames { get; set; } = null;
        [Parameter] public string Title { get; set; }
        [Parameter] public string To { get; set; }
        [Parameter] public XFSidebarItemType SidebarItemType { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        private List<SidebarItemData> ItemsData = new List<SidebarItemData>();
        private string ULClassNames = "nav-flyout";

        protected override async Task OnInitializedAsync()
        {
            switch(SidebarItemType)
            {
                case XFSidebarItemType.Workflow:
                    this.GetWorkflowItems();
                    break;
                case XFSidebarItemType.CubeView:
                    await this.GetCubeViewProfilesAsync();
                    break;
                case XFSidebarItemType.Dashboard:
                    await this.GetDashboardProfilesAsync();
                    break;
                case XFSidebarItemType.Document:
                    this.GetDocumentItems();
                    break;
            }
        }

        private void GetWorkflowItems()
        {
            ItemsData.Add(new SidebarItemData("Clubs", "xf xf-Workflow-flyout", XFSidebarItemType.Workflow));
            ItemsData.Add(new SidebarItemData("Actual", "xf xf-Actual-flyout", XFSidebarItemType.Workflow));
            ItemsData.Add(new SidebarItemData("2011", "xf xf-TimeDim-flyout", XFSidebarItemType.Workflow));
        }

        private async Task GetCubeViewProfilesAsync()
        {
            var userState = authenticationState.Result;
            string cubeViewProfilesFromClaim = userState?.User?.FindFirst("CubeViewProfiles")?.Value;

            if (!string.IsNullOrEmpty(cubeViewProfilesFromClaim))
            {
                List<CubeViewProfileInfo> cubeViewProfiles = await Task.Run(() => JsonConvert.DeserializeObject<List<CubeViewProfileInfo>>(cubeViewProfilesFromClaim));
                foreach (CubeViewProfileInfo cubeViewProfileInfo in cubeViewProfiles)
                {
                    ItemsData.Add(new SidebarItemData(cubeViewProfileInfo?.Profile.NameOrDescription, "xfFlyout xf-PresProfile", XFSidebarItemType.CubeView, cubeViewProfileInfo.Profile.UniqueID, "profile", null));
                }
            }
        }

        private async Task GetDashboardProfilesAsync()
        {
            var userState = authenticationState.Result;
            string dashboardProfilesFromClaim = userState?.User?.FindFirst("DashboardProfiles")?.Value;

            if (!string.IsNullOrEmpty(dashboardProfilesFromClaim))
            {
                List<DashboardProfileInfo> dashboardProfileInfo = await Task.Run(() => JsonConvert.DeserializeObject<List<DashboardProfileInfo>>(dashboardProfilesFromClaim));
                foreach (DashboardProfileInfo dashboardProfile in dashboardProfileInfo)
                {
                    ItemsData.Add(new SidebarItemData(dashboardProfile?.Profile.NameOrDescription, "xfFlyout xf-PresProfile", XFSidebarItemType.Dashboard, dashboardProfile.Profile.UniqueID, "profile", null));
                }
            }
        }

        private void GetDocumentItems()
        {
            ItemsData.Add(new SidebarItemData("Public", "xf xf-Folder-flyout", XFSidebarItemType.Document));
            ItemsData.Add(new SidebarItemData("Users", "xf xf-Folder-flyout", XFSidebarItemType.Document));
            ItemsData.Add(new SidebarItemData("Admin", "xf xf-Folder-flyout", XFSidebarItemType.Document));
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append("nav nav-item");
            base.BuildClasses(builder);
        }

    }
}