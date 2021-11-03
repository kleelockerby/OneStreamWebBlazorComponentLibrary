using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;

namespace OneStreamWebBlazor.Client.Models
{
    public class DashboardProfileViewModel
    {
        public DashboardProfileInfo DashboardProfile { get; set; }
        public List<Dashboard> Dashboards { get; set; } = new List<Dashboard>();

        public DashboardProfileViewModel() { }
        public DashboardProfileViewModel(DashboardProfileInfo dashboardProfile) 
        {
            this.DashboardProfile = dashboardProfile;
        }
    }
}
