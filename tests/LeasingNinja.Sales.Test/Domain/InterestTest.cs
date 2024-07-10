using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain;

public class InterestTest
{
    [Fact]
    void givenAnInterest_whenPerMonth_thenCorrectValue() {
        // given
        var interest = Interest.Of(3.6);

        // when
        double perMonth = interest.PerMonth;

        // then
        Check.That(perMonth).IsEqualTo(0.3);
    }

}
