using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Utilities;
using OneStreamWebBlazor.Components.Helpers;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFTextArea : XFInputBase<string>
    {
        [Parameter] public string Rows { get; set; }
        [Parameter] public string Cols { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.TextArea());
            builder.Append(ClassProvider.TextAreaSize(Size));
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