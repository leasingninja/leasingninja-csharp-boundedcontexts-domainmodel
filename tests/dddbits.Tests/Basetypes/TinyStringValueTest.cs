using System;
using NFluent;
using Xunit;

namespace dddbits.Basetypes
{
    public class TinyStringValueTest
    {
        class Firstname : TinyStringValue
        {
            public Firstname(string value) : base(value)
            {
            }
        }

        class Lastname : TinyStringValue
        {
            public Lastname(string value) : base(value)
            {
            }
        }

        [Fact]
        void GivenAValueObject_whenGetValue_thenValueIsEqualToTheString()
        {
            // given
            TinyStringValue vo = new Firstname("The string value");
            {
            }
   
            // when
            string value = vo.Value;

            // then
            Check.That(value).IsEqualTo("The string value");
        }

        [Fact]
        void GivenTwoValueObjectsOfSameTypeWithSameValue_whenEquals_thenTrue()
        {
            // given
            Firstname vo1 = new Firstname("Otto");
            Firstname vo2 = new Firstname("Otto");

            // when
            bool equal = vo1.Equals(vo2);

            // then
            Check.That(equal).IsTrue();
        }

        [Fact]
        void GivenTwoValueObjectsOfDifferentSubtypeWithSameValue_whenEquals_thenFalse()
        {
            // given
            Firstname vo1 = new Firstname("Otto");
            Lastname vo2 = new Lastname("Otto");

            // when
            bool equal = vo1.Equals(vo2);

            // then
            Check.That(equal).IsFalse();
        }

        [Fact]
        void GivenTwoValueObjectsOfSameTypeWithSameValue_whenOperatorEq_thenTrue()
        {
            // given
            Firstname vo1 = new Firstname("Otto");
            Firstname vo2 = new Firstname("Otto");

            // when
            bool equal = vo1 == vo2;

            // then
            Check.That(equal).IsTrue();
        }

        [Fact]
        void GivenAValueObject_whenCallingToString_thenItReturnsSubClassNameAndValue()
        {
            // given
            Firstname vo = new Firstname("Otto");

            // when
            String str = vo.ToString();

            // then
            Check.That(str).IsEqualTo("Firstname [Otto]");
        }
    }
}