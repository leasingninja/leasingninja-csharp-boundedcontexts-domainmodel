using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain;

public class CurrencyTest
{
    [Fact]
    void GivenTwoUnequalCurrencies_whenEquals_thenAreNotEqual()
    {
        // given
        var currency1 = Currency.EUR;
        var currency2 = Currency.USD;

        // when
        bool areEqual = currency1.Equals(currency2);

        // then
        Check.That(areEqual).IsFalse();
    }
}
