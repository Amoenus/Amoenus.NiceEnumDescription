using System;

namespace Amoenus.NiceEnumDescription
{
    /// <summary>
    ///     The description attribute to associate the description text with an
    ///     <see langword="enum" />
    /// </summary>
    /// <inheritdoc />
    /// <seealso cref="T:System.Attribute" />
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDescriptionAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="EnumDescriptionAttribute" /> class.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <inheritdoc />
        public EnumDescriptionAttribute(string description)
        {
            Description = description;
        }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; }
    }
}