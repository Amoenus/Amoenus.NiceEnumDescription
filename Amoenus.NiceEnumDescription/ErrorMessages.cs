namespace Amoenus.NiceEnumDescription
{
    /// <summary>
    /// Error messages used throughout the library
    /// </summary>
    public static class ErrorMessages
    {
        public static readonly string NoDescriptionOrInvalidEnumMessage =
            $"The Enum does not have {nameof(EnumDescriptionAttribute)} attribute or enum value is outside of range";

        public static readonly string NotValidNotExistOptionMessage =
            $"This is not valid {nameof(NotExistOption)}";
    }
}