using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain
{
    public class AmountTest
    {
        [Fact]
        public void GivenTwoEqualAmounts_whenEquals_thenAreEqual()
        {
            // given
            var amount1 = Amount.Of(100, "EUR");
            var amount2 = Amount.Of(100, "EUR");

            // when
            bool areEqual = amount1.Equals(amount2);

            // then
            Check.That(areEqual).IsTrue();
        }
        
        [Fact]
        public void GivenTwoUnequalAmounts_whenEquals_thenAreNotEqual() {
            // given
            var amount1 = Amount.Of(100, "EUR");
            var amount2 = Amount.Of(200, "EUR");

            // when
            bool areEqual = amount1.Equals(amount2);

            // then
            Check.That(areEqual).IsFalse();
        }

        [Fact]
        public void GivenTwoAmountsWithUnequalCurrencies_whenEquals_thenAreNotEqual() {
            // given
            var amount1 = Amount.Of(100, "EUR");
            var amount2 = Amount.Of(100, "GBP");

            // when
            bool areEqual = amount1.Equals(amount2);

            // then
            Check.That(areEqual).IsFalse();
        }
    }
}