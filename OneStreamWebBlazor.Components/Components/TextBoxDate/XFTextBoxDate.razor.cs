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
    public partial class XFTextBoxDate<TValue> : XFInputBase<TValue>
    {
        private const string DateFormat = "yyyy-MM-dd"; // Compatible with HTML date inputs
        [Parameter] public DateTime? Min { get; set; }
        [Parameter] public DateTime? Max { get; set; }
        [Parameter] public string ParsingErrorMessage { get; set; } = "The {0} field must be a date.";

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.DateEdit());
            builder.Append(ClassProvider.TextEditSize(Size));
            base.BuildClasses(builder);
        }

        protected override string FormatValueAsString(TValue value)
        {
            switch (value)
            {
                //case null:
                //    return null;
                case DateTime datetime:
                    return datetime.ToString(Parsers.InternalDateFormat);
                case DateTimeOffset datetimeOffset:
                    return datetimeOffset.ToString(Parsers.InternalDateFormat);
                default:
                    return string.Empty;
            }
        }

        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);

            bool success;
            if (targetType == typeof(DateTime))
            {
                success = TryParseDateTime(value, out result);
            }
            else if (targetType == typeof(DateTimeOffset))
            {
                success = TryParseDateTimeOffset(value, out result);
            }
            else
            {
                throw new InvalidOperationException($"The type '{targetType}' is not a supported date type.");
            }

            if (success)
            {
                validationErrorMessage = null;
                return true;
            }
            else
            {
                validationErrorMessage = string.Format(ParsingErrorMessage, FieldIdentifier.FieldName);
                return false;
            }
        }

        static bool TryParseDateTime(string value, out TValue result)
        {
            var success = BindConverter.TryConvertToDateTime(value, CultureInfo.InvariantCulture, DateFormat, out var parsedValue);
            if (success)
            {
                result = (TValue)(object)parsedValue;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        static bool TryParseDateTimeOffset(string value, out TValue result)
        {
            var success = BindConverter.TryConvertToDateTimeOffset(value, CultureInfo.InvariantCulture, DateFormat, out var parsedValue);
            if (success)
            {
                result = (TValue)(object)parsedValue;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

    }
}