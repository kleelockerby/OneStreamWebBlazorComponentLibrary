using Microsoft.AspNetCore.Mvc;
using OneStream.Client.Web;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;
using OneStreamWebBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace OneStreamWebBlazor.Server.Controllers
{
    [Route("api/internal/[controller]")]
    [ApiController]
    public class DashboardsController : XFControllerBase
    {
        // POST api/internal/dashboards/GetAllMaintUnits
        [HttpPost("GetAllMaintUnits")]
        public List<DashboardMaintUnit> GetAllMaintUnits([FromBody] XFBaseSiRequestDto xfRequest)
        {
            try
            {
                SessionInfo si = xfRequest.SI ?? new SessionInfo();

                List<DashboardMaintUnit> result = null;
                var dashboardsClient = WcfRetryManager.CreateDashboardsClient(si);
                dashboardsClient.ExecuteRetries(() =>
                {
                    result = dashboardsClient.Channel.GetAllMaintUnits(si, false /*isSystemLevel*/, true /*skipItemsWithNoAccess*/);
                });
                return result;
            }
            catch // (Exception e)
            {
                // LATER. Determine how we should throw or return errors.
                //WebErrorHelper.ThrowAjaxException(si, e, LogException.Default);
            }
            return null;
        }

        // POST api/internal/dashboards/GetGroupsInMaintUnit
        [HttpPost("GetGroupsInMaintUnit")]
        public List<DashboardGroup> GetGroupsInMaintUnit([FromBody] XFGuidRequestDto xfRequest)
        {
            try
            {
                SessionInfo si = xfRequest.SI ?? new SessionInfo();
                Guid maintUnitID = xfRequest.UniqueID;

                if (maintUnitID != Guid.Empty)
                {
                    List<DashboardGroup> result = null;
                    var dashboardsClient = WcfRetryManager.CreateDashboardsClient(si);
                    dashboardsClient.ExecuteRetries(() =>
                    {
                        result = dashboardsClient.Channel.GetGroupsInMaintUnit(si, false /*isSystemLevel*/, maintUnitID);
                    });
                    return result;
                }
            }
            catch // (Exception e)
            {
                // LATER. Determine how we should throw or return errors.
                //WebErrorHelper.ThrowAjaxException(si, e, LogException.Default);
            }
            return null;
        }

        // POST api/internal/dashboards/GetDashboardsInGroup
        [HttpPost("GetDashboardsInGroup")]
        public List<Dashboard> GetDashboardsInGroup([FromBody] XFGuidRequestDto xfRequest)
        {
            try
            {
                SessionInfo si = xfRequest.SI ?? new SessionInfo();
                Guid dashboardGroupID = xfRequest.UniqueID;

                if (dashboardGroupID != Guid.Empty)
                {
                    List<Dashboard> result = null;
                    var dashboardsClient = WcfRetryManager.CreateDashboardsClient(si);
                    dashboardsClient.ExecuteRetries(() =>
                    {
                        result = dashboardsClient.Channel.GetDashboardsInGroup(si, false /*isSystemLevel*/, dashboardGroupID, true /*skipItemsWithNoAccess*/);
                    });
                    return result;
                }
            }
            catch // (Exception e)
            {
                // LATER. Determine how we should throw or return errors.
                //WebErrorHelper.ThrowAjaxException(si, e, LogException.Default);
            }
            return null;
        }

        // POST api/internal/dashboards/GetDashboardDisplayInfoCompressed
        [HttpPost("GetDashboardDisplayInfoCompressed")]
        public CompressionResult GetDashboardDisplayInfoCompressed([FromBody] XFDashboardDisplayInfoRequestDto xfRequest)
        {
            try
            {
                SessionInfo si = xfRequest.SI ?? new SessionInfo();
                LoadDashboardInfo loadDashboardInfo = xfRequest.LoadDashboardInfo;
                Dictionary<string, string> customSubstVars = xfRequest.CustomSubstVars;
                Dictionary<string, bool> visibleAndHiddenEmbeddedDashboards = xfRequest.VisibleAndHiddenEmbeddedDashboards;

                CompressionResult result = null;
                var dashboardsClient = WcfRetryManager.CreateDashboardsClient(si);
                dashboardsClient.ExecuteRetries(() =>
                {
                    result = dashboardsClient.Channel.GetDashboardDisplayInfoCompressed(si, loadDashboardInfo, customSubstVars, visibleAndHiddenEmbeddedDashboards);
                });
                return result;
            }
            catch // (Exception e)
            {
                // LATER. Determine how we should throw or return errors.
                //WebErrorHelper.ThrowAjaxException(si, e, LogException.Default);
            }
            return null;
        }

        // POST api/internal/dashboards/GetDashboardsInProfile
        [HttpPost("GetDashboardsInProfile")]
        public List<Dashboard> GetDashboardsInProfile([FromBody] XFGuidRequestDto xfRequest)
        {
            try
            {
                SessionInfo si = xfRequest.SI ?? new SessionInfo();
                Guid dashboardID = xfRequest.UniqueID;

                List<Dashboard> result = null;
                var dashboardsClient = WcfRetryManager.CreateDashboardsClient(si);
                dashboardsClient.ExecuteRetries(() =>
                {
                    result = dashboardsClient.Channel.GetDashboardsInProfile(si, false, dashboardID, DashboardUIPlatformType.Unknown, true);
                });
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Result Exception:  " + ex.Message);
            }
            return null;
        }

        // POST api/internal/dashboards/GetCubeViewsInProfile
        [HttpPost("GetCubeViewsInProfile")]
        public List<CubeViewItemSummaryInfo> GetCubeViewsInProfile([FromBody] XFGuidRequestDto xfRequest)
        {
            try
            {
                SessionInfo si = xfRequest.SI ?? new SessionInfo();
                Guid cubeViewID = xfRequest.UniqueID;

                List<CubeViewItemSummaryInfo> result = null;
                var cubeViewClient = WcfRetryManager.CreateCubeViewsClient(si);
                cubeViewClient.ExecuteRetries(() =>
                {
                    result = cubeViewClient.Channel.GetCubeViewItemsInProfile(si, cubeViewID, true);
                });
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Result Exception:  " + ex.Message);
            }
            return null;
        }
    }
}
