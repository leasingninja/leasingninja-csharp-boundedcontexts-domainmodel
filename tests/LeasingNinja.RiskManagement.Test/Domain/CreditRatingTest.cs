using NFluent;
using Xunit;

namespace LeasingNinja.RiskManagement.Domain
{
    public class CreditRatingTest
    {
        [Fact]
        void testIsValid()
        {
            Check.That(CreditRating.IsValid(0)).IsFalse();
            Check.That(CreditRating.IsValid(1)).IsTrue();
            Check.That(CreditRating.IsValid(3)).IsTrue();
            Check.That(CreditRating.IsValid(10)).IsTrue();
            Check.That(CreditRating.IsValid(11)).IsFalse();
        }
    }
}
