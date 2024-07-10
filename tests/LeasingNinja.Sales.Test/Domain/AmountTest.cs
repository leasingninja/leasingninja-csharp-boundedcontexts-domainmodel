using System.Globalization;
using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain;

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

    [Fact]
    void givenTwoAmounts_whenOperatorPlus_thenSumIsCorrect()
    {
        // given
        var amount1 = Amount.Of(100, Currency.EUR);
        var amount2 = Amount.Of(200, Currency.EUR);

        // when
        var sum = amount1 + amount2;

        // then
        Check.That(sum).IsEqualTo(Amount.Of(300, Currency.EUR));
    }

    [Fact]
    void givenTwoAmounts_whenOperatorMinus_thenDifferenceIsCorrect()
    {
        // given
        var amount1 = Amount.Of(300, Currency.EUR);
        var amount2 = Amount.Of(200, Currency.EUR);

        // when
        var difference = amount1 - amount2;

        // then
        Check.That(difference).IsEqualTo(Amount.Of(100, Currency.EUR));
    }
}
