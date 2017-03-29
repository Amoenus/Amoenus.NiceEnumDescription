using System;
using System.Collections.Generic;
using Amoenus.NiceEnumDescription;
using NUnit.Framework;
using Shouldly;

namespace Amoenus.NiceEumDescriptionTests
{
    [TestFixture]
    public class NiceEnumTests
    {
        [Test]
        public void GetEnumDescription_GetsExpectedDescription()
        {
            string result1 = TestEnum.TestOne.GetEnumDescription();
            string result2 = TestEnum.TestTwo.GetEnumDescription();
            string result3 = TestEnum.TestThree.GetEnumDescription();
            string result4 = ((TestEnum)4).GetEnumDescription();

            result1.ShouldBe("Test One Description");
            result2.ShouldBe("Test Two Description");
            result3.ShouldBe(nameof(TestEnum.TestThree));
            result4.ShouldBe("4");
        }

        [Test]
        public void GetEnumDescription_GetsExpectedDescriptionOrNull()
        {
            const NotExistOption NotExistOption = NotExistOption.Null;
            string result3 = TestEnum.TestThree.GetEnumDescription(NotExistOption);
            string result4 = ((TestEnum)4).GetEnumDescription(NotExistOption);

            result3.ShouldBeNull();
            result4.ShouldBeNull();
        }

        [Test]
        public void GetEnumDescription_GetsExpectedDescriptionOrEmptyString()
        {
            const NotExistOption NotExistOption = NotExistOption.EmptyString;

            string result3 = TestEnum.TestThree.GetEnumDescription(NotExistOption);
            string result4 = ((TestEnum)4).GetEnumDescription(NotExistOption);

            result3.ShouldBeEmpty();
            result4.ShouldBeEmpty();
        }

        [Test]
        public void GetEnumDescription_GetsExpectedDescriptionOrToString()
        {
            const NotExistOption NotExistOption = NotExistOption.ToString;

            string result3 = TestEnum.TestThree.GetEnumDescription(NotExistOption);
            string result4 = ((TestEnum)4).GetEnumDescription(NotExistOption);

            result3.ShouldBe(nameof(TestEnum.TestThree));
            result4.ShouldBe("4");
        }

        [Test]
        public void GetEnumDescription_Throws()
        {
            var exception = Should.Throw<ArgumentOutOfRangeException>(() => TestEnum.TestThree.GetEnumDescription(NotExistOption.Throw));
            exception.Message.ShouldContain(ErrorMessages.NoDescriptionOrInvalidEnumMessage);
            string actual = exception.ActualValue.ToString();
            actual.ShouldBe(nameof(TestEnum.TestThree));
        }

        [Test]
        public void HasValue_ReturnsExpectedResults()
        {
            bool result1 = TestEnum.TestThree.HasValue();
            bool result2 = TestEnum.TestThree.HasValue();
            bool result3 = TestEnum.TestThree.HasValue();
            bool result4 = ((TestEnum)4).HasValue();

            result1.ShouldBeTrue();
            result2.ShouldBeTrue();
            result3.ShouldBeTrue();
            result4.ShouldBeFalse();
        }

        [Test]
        public void GetEnumDescriptionDictionary_ReturnsDictironaryForEnum()
        {
            var expectedDictionary = new Dictionary<TestEnum, string>
                                     {
                                         {TestEnum.TestOne, TestEnum.TestOne.GetEnumDescription()},
                                         {TestEnum.TestTwo, TestEnum.TestTwo.GetEnumDescription()},
                                         {TestEnum.TestThree, TestEnum.TestThree.GetEnumDescription()}
                                     };

            Dictionary<TestEnum, string> actualDictionary = NiceEnum.GetEnumDescriptionDictionary<TestEnum>();

            actualDictionary.ShouldBe(expectedDictionary);
        }

        [Test]
        public void GetEnumValues_ReturnsEnumValues()
        {
            IEnumerable<TestEnum> expectedList = new List<TestEnum>
                                                 {
                                                     TestEnum.TestOne,
                                                     TestEnum.TestTwo,
                                                     TestEnum.TestThree
                                                 };
            IEnumerable<TestEnum> actualList = NiceEnum.GetEnumValues<TestEnum>();

            actualList.ShouldBe(expectedList);
        }
    }
}