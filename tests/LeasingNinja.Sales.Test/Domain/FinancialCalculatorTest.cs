using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain;

public class FinancialCalculatorTest
{
    [Fact]
    void pmt()
    {
        // given

        // when
        double pmt = FinancialCalculator.Pmt(48, 3.7 / 12, -40_000, 0, 0);

        // then
        Check.That(pmt).IsEqualTo(897.8022814470006);
    }
}
