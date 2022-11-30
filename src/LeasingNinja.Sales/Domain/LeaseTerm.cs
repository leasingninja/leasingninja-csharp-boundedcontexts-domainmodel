using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public readonly record struct LeaseTerm(int NoOfMonths)
    {
        public static LeaseTerm OfMonths(int noOfMonths)
            => new LeaseTerm(noOfMonths);

        public static LeaseTerm OfYears(int noOfYears)
            => new LeaseTerm(noOfYears * 12);
    }
}
