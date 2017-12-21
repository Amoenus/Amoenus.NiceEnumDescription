namespace Amoenus.NiceEnumDescription
{
    /// <summary>
    /// Options that specify how <c>enums</c> without <see cref="EnumDescriptionAttribute"/> are handled
    /// </summary>
    public enum NotExistOption
    {
        ToString,
        EmptyString,
        Null,
        Throw
    }
}