using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Common;
using OneStreamWebBlazor.Components.Helpers;
using OneStreamWebBlazor.Components.Utilities;
using OneStreamWebBlazor.Components.Extensions;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFTextBox : XFInputBase<string>
    {
        [Parameter] public TextRole Role { get; set; } = TextRole.Text;
        [Parameter] public string MaxLength { get; set; }
        [Parameter] public int? VisibleCharacters { get; set; }
        [Parameter] public string Placeholder { get; set; }
        [Parameter] public bool PreventDefault { get; set; }
        [Parameter] public bool StopPropagation { get; set; }
        [Parameter] public EventCallback<string> ValueInputChanged { get; set; }
        [Parameter] public EventCallback OnClicked { get; set; }

        protected string Type => Role.ToTextRoleString();

        protected async Task OnInputAsync(ChangeEventArgs e)
        {
            string _value = e.Value as string;
            await ValueInputChanged.InvokeAsync(_value);
        }

        protected async Task OnClickHandler()
        {
            await OnClicked.InvokeAsync(null);
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.TextEdit());
            builder.Append(ClassProvider.TextEditSize(Size));
            base.BuildClasses(builder);
        }

        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
