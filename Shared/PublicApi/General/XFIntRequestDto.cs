using OneStream.Shared.Common;

namespace OneStreamWebBlazor.Shared
{
    public class XFIntRequestDto : XFBaseSiRequestDto
    {
        public int UniqueId { get; set; }

        public XFIntRequestDto()
            : base()
        {
            this.UniqueId = SharedConstants.Unknown;
        }

        public XFIntRequestDto(SessionInfo si, int uniqueId)
            : base(si)
        {
            this.UniqueId = uniqueId;
        }
    }
}
