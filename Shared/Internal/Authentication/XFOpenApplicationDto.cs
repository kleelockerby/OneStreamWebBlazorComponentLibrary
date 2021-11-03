using OneStream.Shared.Common;
using OneStream.Shared.Wcf;
using System;
using System.Collections.Generic;

namespace OneStreamWebBlazor.Shared
{
    public class XFOpenApplicationDto : XFBaseResponseDto
    {
        //public AjaxOpenAppResult OpenAppResult { get; set; }
        public SessionInfo SessionInfo { get; set; }
        public List<CubeViewProfileInfo> CubeViewProfiles { get; set; }
        public List<DashboardProfileInfo> DashboardProfiles { get; set; }

        public XFOpenApplicationDto()
            : base()
        {
            this.SessionInfo = null;
            this.CubeViewProfiles = new List<CubeViewProfileInfo>();
            this.DashboardProfiles = new List<DashboardProfileInfo>();
        }

        //public XFOpenApplicationDto(AjaxOpenAppResult openAppResult)
        //    : base()
        //{
        //    this.OpenAppResult = openAppResult;
        //}

        public XFOpenApplicationDto(SessionInfo sessionInfo, List<CubeViewProfileInfo> cubeViewProfiles, List<DashboardProfileInfo> dashboardProfiles)
            : base()
        {
            this.SessionInfo = sessionInfo;
            this.CubeViewProfiles = cubeViewProfiles;
            this.DashboardProfiles = dashboardProfiles;
        }
    }
}
