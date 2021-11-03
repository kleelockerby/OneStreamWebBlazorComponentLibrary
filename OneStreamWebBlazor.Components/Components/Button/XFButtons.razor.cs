using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Common;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFButtons : XFComponentBase
    {
        private ButtonsRole role = ButtonsRole.Addons;
        private Orientation orientation = Orientation.Horizontal;
        private ButtonsSize size = ButtonsSize.None;

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter]
        public ButtonsRole Role
        {
            get => role;
            set => role = value;
        }

        [Parameter]
        public Orientation Orientation
        {
            get => orientation;
            set => orientation = value;
        }

        [Parameter]
        public ButtonsSize Size
        {
            get => size;
            set => size = value;
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            //builder.Append(ClassProvider.ButtonsAddons(), Role == ButtonsRole.Addons);
            //builder.Append(ClassProvider.ButtonsToolbar(), Role == ButtonsRole.Toolbar);
            //builder.Append(ClassProvider.ButtonsVertical(), Orientation == Orientation.Vertical);
            //builder.Append(ClassProvider.ButtonsSize(Size), Size != ButtonsSize.None);

            base.BuildClasses(builder);
        }
    }
}