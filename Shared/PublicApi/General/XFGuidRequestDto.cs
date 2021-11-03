using OneStream.Shared.Common;
using System;

namespace OneStreamWebBlazor.Shared
{
    public class XFGuidRequestDto : XFBaseSiRequestDto
    {
        public Guid UniqueID { get; set; }

        public XFGuidRequestDto()
            : base()
        {
            this.UniqueID = Guid.Empty;
        }

        public XFGuidRequestDto(SessionInfo si, Guid uniqueID)
            : base(si)
        {
            this.UniqueID = uniqueID;
        }
    }
}
