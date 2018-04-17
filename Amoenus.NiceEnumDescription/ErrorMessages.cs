using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Amoenus.NiceEumDescriptionTests")]
namespace Amoenus.NiceEnumDescription
{
    /// <summary>
    ///     Error messages used throughout the library
    /// </summary>
    internal static class ErrorMessages
    {
        /// <summary>
        ///     The no description or invalid <see langword="enum" /> message
        /// </summary>
        internal static readonly string NoDescriptionOrInvalidEnumMessage =
            $"The Enum does not have {nameof(EnumDescriptionAttribute)} attribute or enum value is outside of range";

        /// <summary>
        ///     The not valid not exist option message
        /// </summary>
        internal static readonly string NotValidNotExistOptionMessage =
            $"This is not valid {nameof(NotExistOption)}";
    }
}