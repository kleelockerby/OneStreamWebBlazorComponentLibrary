using OneStream.Shared.Common;

namespace OneStreamWebBlazor.Shared
{
    public class XFStringRequestDto : XFBaseSiRequestDto
    {
        public string Name { get; set; }

        public XFStringRequestDto()
            : base()
        {
            this.Name = string.Empty;
        }

        public XFStringRequestDto(SessionInfo si, string name)
            : base(si)
        {
            this.Name = name ?? string.Empty;
        }
    }
}
