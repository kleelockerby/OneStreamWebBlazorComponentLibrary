using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Helpers;
using OneStreamWebBlazor.Components.Utilities;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFTextBoxNumber<TValue> : XFInputBase<TValue>
    {

        [Parameter] public int Decimals { get; set; } = 2;
        [Parameter] public string DecimalsSeparator { get; set; } = ".";
        [Parameter] public TValue Min { get; set; }
        [Parameter] public TValue Max { get; set; }

        [Parameter] public string Placeholder { get; set; }
        [Parameter] public decimal? Step { get; set; }
        [Parameter] public string ParsingErrorMessage { get; set; } = "The {0} field must be a number.";
        [Parameter]public string Culture { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.TextEdit());
            builder.Append(ClassProvider.TextEditSize(Size));
            base.BuildClasses(builder);
        }

        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.InvariantCulture, out result))
            {
                Console.WriteLine("Parse true");
                validationErrorMessage = null;
                return true;
            }
            else
            {
                Console.WriteLine("Parse false");
                validationErrorMessage = string.Format(ParsingErrorMessage, FieldIdentifier.FieldName);
                return false;
            }
        }

        protected override string FormatValueAsString(TValue value)
        {
            switch (value)
            {
                //case null:
                //    return null;
                case int @int:
                    return BindConverter.FormatValue(@int, CultureInfo.InvariantCulture);

                case long @long:
                    return BindConverter.FormatValue(@long, CultureInfo.InvariantCulture);

                case float @float:
                    return BindConverter.FormatValue(@float, CultureInfo.InvariantCulture);

                case double @double:
                    return BindConverter.FormatValue(@double, CultureInfo.InvariantCulture);

                case decimal @decimal:
                    return BindConverter.FormatValue(@decimal, CultureInfo.InvariantCulture);

                default:
                    throw new InvalidOperationException($"Unsupported type {value.GetType()}");
            }
        }

    }
}
