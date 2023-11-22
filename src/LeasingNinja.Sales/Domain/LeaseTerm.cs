using static System.Diagnostics.Debug;

using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public readonly record struct LeaseTerm(int NoOfMonths)
    {
        public static LeaseTerm OfMonths(int noOfMonths)
        {
            Assert(noOfMonths > 0);

            return new LeaseTerm(noOfMonths);
        }

        public static LeaseTerm OfYears(int noOfYears)
            => LeaseTerm.OfMonths(noOfYears * 12);
    }
}
