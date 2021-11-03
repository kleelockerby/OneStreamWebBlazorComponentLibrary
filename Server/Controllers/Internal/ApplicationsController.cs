using Microsoft.AspNetCore.Mvc;
using OneStream.Client.Web;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;
using OneStreamWebBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OneStreamWebBlazor.Server.Controllers
{
    [Route("api/internal/[controller]")]
    [ApiController]
    public class ApplicationsController : XFControllerBase
    {
        // POST api/internal/applications/Logon
        [HttpPost("Logon")]
        public XFLogonResponseDto Logon([FromBody] XFLogonRequestDto xfRequest)
        {
            // Test code to Logon and create a SessionInfo for the client to use.
            try
            {
                SessionInfo si = null;
                if (xfRequest != null)
                {
                    AjaxLogonResult ajaxLogonResult = AuthenticationWebHelper.Logon(string.Empty /*LATER*/, xfRequest.UserName,
                        xfRequest.PasswordOrToken, xfRequest.ClientModuleType, xfRequest.ClientXFVersion);
                    if (ajaxLogonResult != null)
                    {
                        si = ajaxLogonResult.SessionInfo;
                    }
                }
                return new XFLogonResponseDto(si);
            }
            catch // (Exception e)
            {
                // LATER. Determine how we should throw or return errors.
                //WebErrorHelper.ThrowAjaxException(si, e, LogException.Default);
            }
            return null;
        }

        // POST api/internal/applications/GetApplications
        [HttpPost("GetApplications")]
        public XFApplicationsDto GetApplications([FromBody] XFBaseSiRequestDto xfRequest)
        {
            // Sample test.
            //List<XFApplication> applications = new List<XFApplication>();
            //applications.Add(new XFApplication(Guid.NewGuid(), "EZCorp", string.Empty, string.Empty, string.Empty));
            //applications.Add(new XFApplication(Guid.NewGuid(), "Golfstream", string.Empty, string.Empty, string.Empty));
            //return new XFApplicationsDto(applications);

            // Test code to demonstrate this ASP.NET Core Web Server using WCF client code to call our App Server.
            try
            {
                SessionInfo si = xfRequest.SI ?? new SessionInfo();

                XFApplicationAdminInitInfo result = null;
                var environmentClient = WcfRetryManager.CreateEnvironmentClient(si);
                environmentClient.ExecuteRetries(() =>
                {
                    result = environmentClient.Channel.GetApplicationAdminInitInfo(si);
                });

                List<XFApplicationInfo> applicationInfos = result?.Applications;
                applicationInfos ??= new List<XFApplicationInfo>();
                List<XFApplication> applications = (from item in applicationInfos orderby item.Application.Name select item.Application).ToList();
                return new XFApplicationsDto(applications);
            }
            catch // (Exception e)
            {
                // LATER. Determine how we should throw or return errors.
                //WebErrorHelper.ThrowAjaxException(si, e, LogException.Default);
            }
            return null;
        }

        //// TEST CODE to see JSON serialization.
        //// GET internal/applications/GetSessionInfo
        //[HttpGet("GetSessionInfo")]
        //public SessionInfo GetSessionInfo()
        //{
        //    // Sample test.
        //    SessionInfo si = new SessionInfo(ClientModuleType.WebApi, "", null, null, "en-US");
        //    return si;
        //}
    }
}
