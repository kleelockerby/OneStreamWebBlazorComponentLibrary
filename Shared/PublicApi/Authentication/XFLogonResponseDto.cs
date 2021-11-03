using OneStream.Shared.Common;

namespace OneStreamWebBlazor.Shared
{
    public class XFLogonResponseDto : XFBaseResponseDto
    {
        public SessionInfo SI { get; set; }

        public XFLogonResponseDto()
            : base()
        {
            this.SI = null;
        }

        public XFLogonResponseDto(SessionInfo si)
            : base()
        {
            this.SI = si;
        }
    }
}
