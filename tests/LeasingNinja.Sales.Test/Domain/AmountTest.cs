using System.Globalization;
using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain
{
    public class AmountTest
    {
        public AmountTest()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [Fact]
        void GivenTwoEqualAmounts_whenEquals_thenAreEqual()
        {
            // given
            var amount1 = Amount.Of(100m, Currency.EUR);
            var amount2 = Amount.Of(100m, Currency.EUR);

            // when
            bool areEqual = amount1.Equals(amount2);

            // then
            Check.That(areEqual).IsTrue();
        }

        [Fact]
        void GivenTwoUnequalAmounts_whenEquals_thenAreNotEqual() {
            // given
            var amount1 = Amount.Of(100m, Currency.EUR);
            var amount2 = Amount.Of(200m, Currency.EUR);

            // when
            bool areEqual = amount1.Equals(amount2);

            // then
            Check.That(areEqual).IsFalse();
        }

        [Fact]
        void GivenTwoAmountsWithUnequalCurrencies_whenEquals_thenAreNotEqual() {
            // given
            var amount1 = Amount.Of(100m, Currency.EUR);
            var amount2 = Amount.Of(100m, Currency.GBP);

            // when
            bool areEqual = amount1.Equals(amount2);

            // then
            Check.That(areEqual).IsFalse();
        }

        [Fact]
        void givenTwoAmountsWithRoundingAfterThePoint_whenEquals_thenAreEqual() {
            // given
            var amount1 = Amount.Of(100.45m, Currency.EUR);
            var amount2 = Amount.Of(100.447123m, Currency.EUR);

            // when
            bool areEqual = amount1.Equals(amount2);

            // then
            Check.That(areEqual).IsTrue();
        }

        [Fact]
        void givenAnAmountsWithCents_whenToString_thenAfterThePointIsCorrectlyPrinted() {
           // given
            var amount = Amount.Of(100.45m, Currency.EUR);

            // when
            string amountString = amount.ToString();

            // then
            Check.That(amountString).IsEqualTo("EUR 100.45");
        }

        [Fact]
        void givenTwoAmountsOfEurosAndCents_whenEquals_thenAreEqual() {
            // given
            var amount1 = Amount.Of(100.45m, Currency.EUR);
            var amount2 = Amount.OfCents(10045, Currency.EUR);

            // when
            bool areEqual = amount1.Equals(amount2);

            // then
            Check.That(areEqual).IsTrue();
        }
    }
}
