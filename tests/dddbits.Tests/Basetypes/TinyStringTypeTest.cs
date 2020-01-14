using System;
using NFluent;
using Xunit;

namespace dddbits.Basetypes
{
    public class TinyStringTypeTest
    {
        class Firstname : TinyStringType
        {
            public Firstname(string value) : base(value)
            {
            }
        }

        class Lastname : TinyStringType
        {
            public Lastname(string value) : base(value)
            {
            }
        }

        [Fact]
        void givenAValueObject_whenGetValue_thenValueIsEqualToTheString()
        {
            // given
            TinyStringType vo = new Firstname("The string value");
            {
            }
   
            // when
            string value = vo.Value;

            // then
            Check.That(value).IsEqualTo("The string value");
        }

        [Fact]
        void givenTwoValueObjectsOfSameTypeWithSameValue_whenEquals_thenTrue()
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
        void givenTwoValueObjectsOfDifferentSubtypeWithSameValue_whenEquals_thenFalse()
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
        void givenTwoValueObjectsOfSameTypeWithSameValue_whenOperatorEq_thenTrue()
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
        void givenAValueObject_whenCallingToString_thenItReturnsSubClassNameAndValue()
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