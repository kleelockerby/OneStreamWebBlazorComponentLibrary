using System;
using System.Collections.Generic;
using System.Globalization;

namespace OneStreamWebBlazor.Components.Utilities
{
    public static class Converters
    {
        public static TValue ChangeType<TValue>(object o)
        {
            Type conversionType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
            if (conversionType.IsEnum && EnumTryParse(o?.ToString(), conversionType, out TValue value))
            {
                return value;
            }
            return (TValue)Convert.ChangeType(o, conversionType);
        }

        public static bool TryChangeType<TValue>(object value, out TValue result, CultureInfo cultureInfo = null)
        {
            try
            {
                Type conversionType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);

                if (conversionType.IsEnum && EnumTryParse(value?.ToString(), conversionType, out TValue theEnum))
                    result = theEnum;
                else if (conversionType == typeof(Guid))
                    result = (TValue)Convert.ChangeType(Guid.Parse(value.ToString()), conversionType);
                else
                    result = (TValue)Convert.ChangeType(value, conversionType, cultureInfo ?? CultureInfo.InvariantCulture);

                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
        public static bool EnumTryParse<TValue>(string input, Type conversionType, out TValue theEnum)
        {
            if (input != null)
            {
                foreach (string en in Enum.GetNames(conversionType))
                {
                    if (en.Equals(input, StringComparison.InvariantCultureIgnoreCase))
                    {
                        theEnum = (TValue)Enum.Parse(conversionType, input, true);
                        return true;
                    }
                }
            }
            theEnum = default;
            return false;
        }

        public static string FormatValue(byte value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(byte? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(short value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(short? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(int value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(int? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(long value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(long? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(float value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(float? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(double value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(double? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(decimal value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(decimal? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(sbyte value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(sbyte? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(ushort value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(ushort? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(uint value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(uint? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(ulong value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(ulong? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(DateTime value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(DateTime? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(DateTimeOffset value, CultureInfo culture = null) => value.ToString(culture ?? CultureInfo.CurrentCulture);

        public static string FormatValue(DateTimeOffset? value, CultureInfo culture = null) => value?.ToString(culture ?? CultureInfo.CurrentCulture);

        public static (object, object) GetMinMaxValueOfType<TValue>()
        {
            var type = typeof(TValue);

            switch (type)
            {
                case Type byteType when byteType == typeof(byte) || byteType == typeof(byte?):
                    return (byte.MinValue, byte.MaxValue);
                case Type shortType when shortType == typeof(short) || shortType == typeof(short?):
                    return (short.MinValue, short.MaxValue);
                case Type intType when intType == typeof(int) || intType == typeof(int?):
                    return (int.MinValue, int.MaxValue);
                case Type longType when longType == typeof(long) || longType == typeof(long?):
                    return (long.MinValue, long.MaxValue);
                case Type floatType when floatType == typeof(float) || floatType == typeof(float?):
                    return (float.MinValue, float.MaxValue);
                case Type doubleType when doubleType == typeof(double) || doubleType == typeof(double?):
                    return (double.MinValue, double.MaxValue);
                case Type decimalType when decimalType == typeof(decimal) || decimalType == typeof(decimal?):
                    return (decimal.MinValue, decimal.MaxValue);
                case Type sbyteType when sbyteType == typeof(sbyte) || sbyteType == typeof(sbyte?):
                    return (sbyte.MinValue, sbyte.MaxValue);
                case Type ushortType when ushortType == typeof(ushort) || ushortType == typeof(ushort?):
                    return (ushort.MinValue, ushort.MaxValue);
                case Type uintType when uintType == typeof(uint) || uintType == typeof(uint?):
                    return (uint.MinValue, uint.MaxValue);
                case Type ulongType when ulongType == typeof(ulong) || ulongType == typeof(ulong?):
                    return (ulong.MinValue, ulong.MaxValue);
                default:
                    throw new InvalidOperationException($"Unsupported type {type}");
            }
        }
    }
}
