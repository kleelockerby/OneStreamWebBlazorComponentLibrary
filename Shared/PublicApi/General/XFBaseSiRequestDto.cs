using OneStream.Shared.Common;

namespace OneStreamWebBlazor.Shared
{
    public class XFBaseSiRequestDto : XFBaseRequestDto
    {
        public SessionInfo SI { get; set; }

        public XFBaseSiRequestDto()
        {
            this.SI = null;
        }

        public XFBaseSiRequestDto(SessionInfo si)
        {
            this.SI = si;
        }
    }
}
