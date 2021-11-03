using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;

namespace OneStreamWebBlazor.Shared
{
    public class XFLogonRequestDto : XFBaseDto
    {
        [Required]
        public string WebServerUrl { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string PasswordOrToken { get; set; }

        public XFApplication SelectedApplication { get; set; }

        public ClientModuleType ClientModuleType { get; set; }

        public string ClientXFVersion { get; set; }

        public XFLogonRequestDto()
            : base()
        {
            this.WebServerUrl = string.Empty;
            this.UserName = string.Empty;
            this.PasswordOrToken = string.Empty;
            this.ClientModuleType = ClientModuleType.Unknown;
            this.ClientXFVersion = string.Empty;
            this.SelectedApplication = new XFApplication();
        }

        public XFLogonRequestDto(string webServerUrl,  string userName, string passwordOrToken, ClientModuleType clientModuleType, string clientXFVersion, XFApplication selectedApplication)
            : base()
        {
            this.WebServerUrl = webServerUrl ?? string.Empty;
            this.UserName = userName ?? string.Empty;
            this.PasswordOrToken = passwordOrToken ?? string.Empty;
            this.ClientModuleType = clientModuleType;
            this.ClientXFVersion = clientXFVersion ?? string.Empty;
            this.SelectedApplication = selectedApplication;
        }
    }
}
