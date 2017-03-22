using Amoenus.NiceEnumDescription;
using NUnit.Framework;
using Shouldly;

namespace Amoenus.NiceEumDescriptionTests
{
    [TestFixture]
    public class NiceEnumTests
    {
        enum TestEnum
        {
            [EnumDescription("Test One Description")]
            TestOne,
            [EnumDescription("Test Two Description")]
            TestTwo,
            TestThree
        }

        [Test]
        public void TestMethod()
        {
            var result1 = TestEnum.TestOne.GetEnumDescription();
            var result2 = TestEnum.TestTwo.GetEnumDescription();
            var result3 = TestEnum.TestThree.GetEnumDescription();

            result1.ShouldBe("Test One Description");
            result2.ShouldBe("Test Two Description");
            result3.ShouldBe("TestThree");
        }

        [Test]
        public void TestMethod2()
        {
            var result3 = TestEnum.TestThree.GetEnumDescription(NotExistOption.Null);
            result3.ShouldBeNull();
        }

        [Test]
        public void TestMethod3()
        {
            var result3 = TestEnum.TestThree.GetEnumDescription(NotExistOption.EmptyString);
            result3.ShouldBeEmpty();
        }
    }
}
