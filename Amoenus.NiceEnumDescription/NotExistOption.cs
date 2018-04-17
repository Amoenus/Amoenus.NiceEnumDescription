namespace Amoenus.NiceEnumDescription
{
    /// <summary>
    ///     Options that specify how <c>enums</c> without
    ///     <see cref="EnumDescriptionAttribute" /> are handled
    /// </summary>
    public enum NotExistOption
    {
        /// <summary>
        ///     If no description attribute found return <see cref="ToString" />
        ///     representation of an <see langword="enum" />
        /// </summary>
        ToString,

        /// <summary>
        ///     If no description attribute found return the empty string
        /// </summary>
        EmptyString,

        /// <summary>
        ///     If no description attribute found return <see langword="null" />
        /// </summary>
        Null,

        /// <summary>
        ///     If no description attribute found return <see langword="throw" /> an
        ///     exception
        /// </summary>
        Throw
    }
}