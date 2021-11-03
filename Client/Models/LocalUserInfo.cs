using OneStream.Shared.Common;
using OneStream.Shared.Wcf;
using System.Collections.Generic;

namespace OneStreamWebBlazor.Client.Models
{
    public class LocalUserInfo
    {
        public SessionInfo SessionInfo { get; set; }
        public string SessionInfoToken { get; set; }
        public string ApplicationName { get; set; }
        public string UserName { get; set; }
        public string BaseUrl { get; set; }
        public string AccessToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public List<CubeViewProfileInfo> CubeViewProfiles { get; set; }
        public List<DashboardProfileInfo> DashboardProfiles { get; set; }
        public  LocalUserInfo()
        {
            this.SessionInfo = null;
            this.CubeViewProfiles = new List<CubeViewProfileInfo>();
            this.DashboardProfiles = new List<DashboardProfileInfo>();
        }
     }
}
