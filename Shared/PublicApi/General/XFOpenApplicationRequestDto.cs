using System;
using System.Collections.Generic;
using System.Text;

namespace OneStreamWebBlazor.Shared
{
    public class XFOpenApplicationRequestDto: XFBaseSiRequestDto
    {
        public string ApplicationName { get; set; }
        
        public XFOpenApplicationRequestDto()
        {
            this.ApplicationName = string.Empty;
        }

        public XFOpenApplicationRequestDto(string applicationName)
        {
            this.ApplicationName = applicationName;
        }
    }
}
