using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Common;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFButton : XFComponentBase
    {
        private Color color = Color.None;
        private ButtonSize size = ButtonSize.None;
        private bool outline;
        private bool disabled;
        private bool active;
        private bool block;
        private bool loading;

        [Parameter] public bool PreventDefaultOnSubmit { get; set; }
        //[CascadingParameter] protected XFDropDown ParentDropdown { get; set; }
        [Parameter] public EventCallback Clicked { get; set; }
        [Parameter] public ButtonType Type { get; set; } = ButtonType.Button;
        [Parameter] public ICommand Command { get; set; }
        [Parameter] public object CommandParameter { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter]
        public Color Color
        {
            get => color;
            set => color = value;
        }

        [Parameter]
        public ButtonSize Size
        {
            get => size;
            set => size = value;
        }

        [Parameter]
        public bool Outline
        {
            get => outline;
            set => outline = value;
        }

        [Parameter]
        public bool Disabled
        {
            get => disabled;
            set => disabled = value;
        }

        [Parameter]
        public bool Active
        {
            get => active;
            set => active = value;
        }

        [Parameter]
        public bool Block
        {
            get => block;
            set => block = value;
        }

        [Parameter]
        public bool Loading
        {
            get => loading;
            set => loading = value;
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            //builder.Append(ClassProvider.Button());
            //builder.Append(ClassProvider.ButtonColor(Color), Color != Color.None && !Outline);
            //builder.Append(ClassProvider.ButtonOutline(Color), Color != Color.None && Outline);
            //builder.Append(ClassProvider.ButtonSize(Size), Size != ButtonSize.None);
            //builder.Append(ClassProvider.ButtonBlock(), Block);
            //builder.Append(ClassProvider.ButtonActive(), Active);
            //builder.Append(ClassProvider.ButtonLoading(), Loading);
            base.BuildClasses(builder);
        }

        protected void ClickHandler()
        {
            if (!Disabled)
            {
                Clicked.InvokeAsync(null);
                if (Command?.CanExecute(CommandParameter) ?? false)
                {
                    Command.Execute(CommandParameter);
                }
            }
        }
    }
}