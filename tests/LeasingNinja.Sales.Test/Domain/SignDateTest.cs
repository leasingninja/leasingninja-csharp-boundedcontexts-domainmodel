using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain;

public class SignDateTest
{
    [Fact]
    void test()
    {
        // when
        var signDate1 = SignDate.Of(2018, 8, 4);
        var signDate2 = SignDate.Of(2018, 8, 4);

        // then
        Check.That(signDate1).IsEqualTo(signDate2);
    }
}
