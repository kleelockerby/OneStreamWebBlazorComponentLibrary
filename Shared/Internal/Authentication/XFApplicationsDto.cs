using OneStream.Shared.Wcf;
using System.Collections.Generic;

namespace OneStreamWebBlazor.Shared
{
    public class XFApplicationsDto : XFBaseResponseDto
    {
        public List<XFApplication> Applications { get; set; }

        public XFApplicationsDto()
            : base()
        {
            this.Applications = null;
        }

        public XFApplicationsDto(List<XFApplication> applications)
            : base()
        {
            this.Applications = applications;
        }
    }
}
