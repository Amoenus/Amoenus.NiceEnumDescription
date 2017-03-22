using System;
using System.Reflection;

namespace Amoenus.NiceEnumDescription
{
    public static class NiceEnum
    {
        public static string GetEnumDescriptionOrNull(this Enum enumeration)
        {
            return GetEnumDescription(enumeration, NotExistOption.Null);
        }

        public static string GetEnumDescriptionOrEmptyString(this Enum enumeration)
        {
            return GetEnumDescription(enumeration, NotExistOption.EmptyString);
        }

        public static string GetEnumDescription(this Enum enumeration,
                                                NotExistOption notExistOption = NotExistOption.ToString)
        {
            FieldInfo fieldInfo = enumeration.GetType().GetRuntimeField(enumeration.ToString());

            if (!enumeration.HasValue())
                return ReturnValueForNotExist(enumeration, notExistOption);

            var attribute =
                (EnumDescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attribute.Length > 0)
                return attribute[0].Description;

            return ReturnValueForNotExist(enumeration, notExistOption);
        }

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
                default:
                    throw new ArgumentOutOfRangeException(nameof(notExistOption), notExistOption, null);
            }
        }

        public static bool HasValue(this Enum enumeration)
        {
            if (enumeration == null)
                return false;

            Type type = enumeration.GetType();

            if (type.Equals(null))
                return false;

            FieldInfo fieldInfo = enumeration.GetType().GetRuntimeField(enumeration.ToString());

            return !fieldInfo.Equals(null);
        }
    }
}