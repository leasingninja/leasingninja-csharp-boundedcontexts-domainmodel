using NFluent;
using NodaTime;
using Xunit;

namespace dddbits.Basetypes
{
    public class TinyDateValueTest
    {
        class DateOfBirth : TinyDateValue
        {
            public DateOfBirth(int year, int month, int dayOfYear) : base(year, month, dayOfYear)
            {
            }
        }

        class DateOfIssue : TinyDateValue
        {
            public DateOfIssue(int year, int month, int dayOfYear) : base(year, month, dayOfYear)
            {
            }
        }

        [Fact]
        void GivenValueObject_whenGetProperties_thenPropertiesAreEqualToTheDate()
        {
            // given
            TinyDateValue vo = new DateOfBirth(2012, 12, 6)
            {
            };

            // when
            int year = vo.Year;
            int month = vo.Month;
            int day = vo.Day;

            // then
            Check.That(year).IsEqualTo(2012);
            Check.That(month).IsEqualTo(12);
            Check.That(day).IsEqualTo(6);
        }

        [Fact]
        void GivenAValueObject_whenGetValue_thenValueIsEqualToTheDate()
        {
            // given
            TinyDateValue vo = new DateOfBirth(2012, 12, 6)
            {
            };

            // when
            LocalDate value = vo.Value;

            // then
            Check.That(value).IsEqualTo(new LocalDate(2012, 12, 6));
        }

        [Fact]
        void GivenTwoValueObjectsOfSameTypeWithSameValue_whenEquals_thenTrue()
        {
            // given
            DateOfBirth vo1 = new DateOfBirth(2012, 12, 6);
            DateOfBirth vo2 = new DateOfBirth(2012, 12, 6);

            // when
            bool equal = vo1.Equals(vo2);

            // then
            Check.That(equal).IsTrue();
        }

        [Fact]
        void givenTwoValueObjectsOfSameTypeWithDifferentValue_whenEquals_thenFalse()
        {
            // given
            DateOfBirth vo1 = new DateOfBirth(2012, 12, 6);
            DateOfBirth vo2 = new DateOfBirth(2014, 1, 18);

            // when
            bool equal = vo1.Equals(vo2);

            // then
            Check.That(equal).IsFalse();
        }

//	// TODO: this is debatable. Do we really want this to show the possibility?
//	@Test
//	void givenTwoValueObjectsOfDifferentSubtypeWithSameValue_whenEquals_thenTrue() {
//		// given
//		var vo1 = new DateOfBirth(2012, 12, 6);
//		var vo2 = new DateOfIssue(2012, 12, 6);
//		
//		// when
//		@SuppressWarnings("unlikely-arg-type")
//		boolean equal = vo1.equals(vo2);
//		
//		// then
//		assertThat(equal).isTrue();
//	}
//

        [Fact]
        void givenAValueObject_whenCallingToString_thenItReturnsSubClassNameAndValue()
        {
            // given
            DateOfBirth vo = new DateOfBirth(2012, 12, 6);

            // when
            string str = vo.ToString();

            // then
            //Check.That(str).IsEqualTo("DateOfBirth [2012-12-06]"); TODO: test without dependency to CurrentCulture
            Check.That(str).IsEqualTo("DateOfBirth [Thursday, 06 December 2012]");
        }
    }
}