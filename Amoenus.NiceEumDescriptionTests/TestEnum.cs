using Amoenus.NiceEnumDescription;

namespace Amoenus.NiceEumDescriptionTests
{
    internal enum TestEnum
    {
        [EnumDescription("Test One Description")]
        TestOne,
        [EnumDescription("Test Two Description")]
        TestTwo,
        TestThree
    }
}