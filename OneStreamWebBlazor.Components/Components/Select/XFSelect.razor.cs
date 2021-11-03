using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneStreamWebBlazor.Components.Common;
using OneStreamWebBlazor.Components.Helpers;
using OneStreamWebBlazor.Components.Utilities;

namespace OneStreamWebBlazor.Components.Components
{
    public partial class XFSelect<TValue> : XFInputBase<IReadOnlyList<TValue>>
    {
        [Parameter] public TValue SelectedValue { get; set; }
        [Parameter] public EventCallback<TValue> SelectedValueChanged { get; set; }
        [Parameter] public Expression<Func<TValue>> SelectedValueExpression { get; set; }
        [Parameter] public int? MaxVisibleItems { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.Select() );
            if(Size != TextBoxSize.None)
            {
                builder.Append(ClassProvider.SelectSize(Size));
            }
            base.BuildClasses(builder);
        }

        protected override string FormatValueAsString(IReadOnlyList<TValue> value)
        {
            if (value == null || value.Count == 0)
                return string.Empty;

            if (value[0] == null)
                return string.Empty;

            return value[0].ToString();
        }

        protected override bool TryParseValueFromString(string value, out IReadOnlyList<TValue> result, out string validationErrorMessage)
        {
            
            if (Converters.TryChangeType<TValue>(value, out var parsedValue))
            {
                var parsedResults = new ParseValue<IReadOnlyList<TValue>>(true, new TValue[] { parsedValue }, null);
                validationErrorMessage = parsedResults.ErrorMessage;
                result = parsedResults.ParsedValue;
                return parsedResults.Success;
            }
            else
            {
                result = default;
                validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not valid.";
                return false;
            }
        }

        public bool ContainsValue(TValue value)
        {
            var currentValue = CurrentValue;
            if (currentValue != null)
            {
                var result = currentValue.Any(x => EqualityComparer<TValue>.Default.Equals(x, value));
                return result;
            }

            return false;
        }
    }
}
