using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Common;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFCard : XFComponentBase
    {
        private bool isWhiteText;
        private Background background = Background.None;

        [Parameter]
        public bool WhiteText
        {
            get => isWhiteText;
            set => isWhiteText = value;
        }

        [Parameter]
        public Background Background
        {
            get => background;
            set => background = value;
        }

        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.Card());
            base.BuildClasses(builder);
        }

    }
}