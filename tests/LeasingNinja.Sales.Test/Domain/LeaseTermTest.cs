using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain
{
    public class LeaseTermTest
    {
        [Fact]
        void given_whenALeaseTermIsCreatedOfYears_thenNoOfMonthsIsCorrect()
        {
            // given

            // when
            var leaseTerm = LeaseTerm.OfYears(4);

            // then
            Check.That(leaseTerm.NoOfMonths).IsEqualTo(48);
        }
    }
}
