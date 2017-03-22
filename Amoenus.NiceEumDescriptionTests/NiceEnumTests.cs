using Amoenus.NiceEnumDescription;
using NUnit.Framework;
using Shouldly;

namespace Amoenus.NiceEumDescriptionTests
{
    [TestFixture]
    public class NiceEnumTests
    {
        [Test]
        public void TestMethod()
        {
            string result1 = TestEnum.TestOne.GetEnumDescription();
            string result2 = TestEnum.TestTwo.GetEnumDescription();
            string result3 = TestEnum.TestThree.GetEnumDescription();

            result1.ShouldBe("Test One Description");
            result2.ShouldBe("Test Two Description");
            result3.ShouldBe("TestThree");
        }

        [Test]
        public void TestMethod2()
        {
            string result3 = TestEnum.TestThree.GetEnumDescription(NotExistOption.Null);
            result3.ShouldBeNull();
        }

        [Test]
        public void TestMethod3()
        {
            string result3 = TestEnum.TestThree.GetEnumDescription(NotExistOption.EmptyString);
            result3.ShouldBeEmpty();
        }

        [Test]
        public void TestMethod4()
        {
            string result3 = TestEnum.TestThree.GetEnumDescription(NotExistOption.ToString);
            result3.ShouldBe(nameof(TestEnum.TestThree));
        }

        [Test]
        public void TestMethod5()
        {
            bool result1 = TestEnum.TestThree.HasValue();
            bool result2 = TestEnum.TestThree.HasValue();
            bool result3 = TestEnum.TestThree.HasValue();

            result1.ShouldBeTrue();
            result2.ShouldBeTrue();
            result3.ShouldBeTrue();
        }
    }
}
