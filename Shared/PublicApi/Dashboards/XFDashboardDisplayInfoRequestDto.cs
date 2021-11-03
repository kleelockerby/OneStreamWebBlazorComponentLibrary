using OneStream.Shared.Common;
using OneStream.Shared.Wcf;
using System.Collections.Generic;

namespace OneStreamWebBlazor.Shared
{
    public class XFDashboardDisplayInfoRequestDto : XFBaseSiRequestDto
    {
        public LoadDashboardInfo LoadDashboardInfo { get; set; }
        public Dictionary<string, string> CustomSubstVars { get; set; }
        public Dictionary<string, bool> VisibleAndHiddenEmbeddedDashboards { get; set; }

        public XFDashboardDisplayInfoRequestDto()
            : base()
        {
            this.LoadDashboardInfo = null;
            this.CustomSubstVars = null;
            this.VisibleAndHiddenEmbeddedDashboards = null;
        }

        public XFDashboardDisplayInfoRequestDto(SessionInfo si, LoadDashboardInfo loadDashboardInfo,
            Dictionary<string, string> customSubstVars, Dictionary<string, bool> visibleAndHiddenEmbeddedDashboards)
            : base(si)
        {
            this.LoadDashboardInfo = loadDashboardInfo;
            this.CustomSubstVars = customSubstVars;
            this.VisibleAndHiddenEmbeddedDashboards = visibleAndHiddenEmbeddedDashboards;
        }
    }
}
