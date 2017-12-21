using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Amoenus.NiceEnumDescription
{
    /// <summary>
    ///     Container class for <see cref="NiceEnum" /> extension methods
    /// </summary>
    public static class NiceEnum
    {
        /// <summary>
        ///     Gets the <see langword="enum" /> description or null.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>
        /// </returns>
        public static string GetEnumDescriptionOrNull(this Enum enumeration)
        {
            return GetEnumDescription(enumeration, NotExistOption.Null);
        }

        /// <summary>
        ///     Gets the <see langword="enum" /> description or empty string.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>
        /// </returns>
        public static string GetEnumDescriptionOrEmptyString(this Enum enumeration)
        {
            return GetEnumDescription(enumeration, NotExistOption.EmptyString);
        }

        /// <summary>
        ///     Gets the <see langword="enum" /> description or string
        ///     representation of an enum.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>
        /// </returns>
        public static string GetEnumDescription(this Enum enumeration)
        {
            return GetEnumDescription(enumeration, NotExistOption.ToString);
        }

        /// <summary>
        ///     <para>
        ///         Gets the <see langword="enum" /> description or representation as
        ///         specified by <see cref="NotExistOption" />
        ///     </para>
        ///     <para>of an enum.</para>
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <param name="notExistOption">The not exist option.</param>
        /// <returns>
        /// </returns>
        public static string GetEnumDescription(this Enum enumeration, NotExistOption notExistOption)
        {
            FieldInfo fieldInfo = enumeration.GetType().GetRuntimeField(enumeration.ToString());

            if (!enumeration.HasValue())
            {
                return ReturnValueForNotExist(enumeration, notExistOption);
            }

            string attribute = GetDescriptionFromAttribute(fieldInfo);

            return string.IsNullOrWhiteSpace(attribute)
                ? ReturnValueForNotExist(enumeration, notExistOption)
                : attribute;
        }

        /// <summary>
        ///     Gets the description from attribute.
        /// </summary>
        /// <param name="fieldInfo">The field information.</param>
        /// <returns>
        /// </returns>
        private static string GetDescriptionFromAttribute(FieldInfo fieldInfo)
        {
            var attribute =
                (EnumDescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            return attribute.Length > 0
                ? attribute.First().Description
                : null;
        }

        /// <summary>
        ///     Returns the value for not existing description.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <param name="notExistOption">The not exist option.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <para>
        ///         <paramref name="notExistOption" />
        ///     </para>
        ///     <list type="bullet">
        ///         <item>
        ///             <description>
        ///                 <see langword="null" />
        ///             </description>
        ///         </item>
        ///     </list>
        /// </exception>
        /// <returns>
        /// </returns>
        private static string ReturnValueForNotExist(Enum enumeration, NotExistOption notExistOption)
        {
            switch (notExistOption)
            {
                case NotExistOption.Null:
                    return null;
                case NotExistOption.ToString:
                    return enumeration.ToString();
                case NotExistOption.EmptyString:
                    return string.Empty;
                case NotExistOption.Throw:
                    throw new ArgumentOutOfRangeException(nameof(enumeration), enumeration,
                        ErrorMessages.NoDescriptionOrInvalidEnumMessage);
                default:
                    throw new ArgumentOutOfRangeException(nameof(notExistOption), notExistOption,
                        ErrorMessages.NotValidNotExistOptionMessage);
            }
        }

        /// <summary>
        ///     Gets the <see langword="enum" /> description dictionary.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="notExistOption">The not exist option.</param>
        /// <exception cref="ArgumentException">
        ///     <typeparamref name="TEnum" /> is not an Enum
        /// </exception>
        /// <returns>
        /// </returns>
        public static Dictionary<TEnum, string> GetEnumDescriptionDictionary<TEnum>(
            NotExistOption notExistOption = NotExistOption.ToString)
        {
            Type enumType = typeof(TEnum);

            CheckIsEnumStrict<TEnum>(enumType);

            var dictionary = new Dictionary<TEnum, string>();

            IEnumerable<TEnum> enumValues = GetEnumValues<TEnum>();

            foreach (TEnum enumValue in enumValues)
            {
                var pureEnumValue = enumValue as Enum;
                dictionary.Add(enumValue, pureEnumValue.GetEnumDescription(notExistOption));
            }

            return dictionary;
        }

        private static void CheckIsEnumStrict<TEnum>(Type enumType)
        {
            if (!enumType.GetTypeInfo().IsEnum)
            {
                throw new ArgumentException(nameof(TEnum), $"{nameof(TEnum)} is not an Enum");
            }
        }

        /// <summary>
        ///     Gets the <see langword="enum" /> values.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <exception cref="ArgumentException">
        ///     <para>
        ///         <typeparamref name="TEnum" />
        ///     </para>
        ///     <list type="bullet">
        ///         <item>
        ///             <description>
        ///                 <typeparamref name="TEnum" />
        ///             </description>
        ///         </item>
        ///     </list>
        /// </exception>
        /// <returns>
        /// </returns>
        public static IEnumerable<TEnum> GetEnumValues<TEnum>()
        {
            Type enumType = typeof(TEnum);

            CheckIsEnumStrict<TEnum>(enumType);

            IEnumerable<TEnum> enumValues = Enum.GetValues(enumType).Cast<TEnum>();
            return enumValues;
        }

        /// <summary>
        ///     Determines whether this instance has value.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>
        ///     <c>true</c> if the specified <paramref name="enumeration" /> has
        ///     value; otherwise, <c>false</c> .
        /// </returns>
        public static bool HasValue(this Enum enumeration)
        {
            Type type = enumeration?.GetType();

            FieldInfo fieldInfo = type?.GetRuntimeField(enumeration.ToString());

            bool hasValue = fieldInfo != null;

            return hasValue;
        }
    }
}