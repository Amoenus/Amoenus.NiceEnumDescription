using System;

namespace Amoenus.NiceEnumDescription
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDescriptionAttribute : Attribute
    {
        private readonly string _description;
        public string Description => _description;

        public EnumDescriptionAttribute(string description)
        {
            _description = description;
        }
    }
}