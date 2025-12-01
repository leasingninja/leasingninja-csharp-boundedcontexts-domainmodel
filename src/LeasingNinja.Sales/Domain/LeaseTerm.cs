using static System.Diagnostics.Debug;

using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain;

[ValueObject]
public readonly record struct LeaseTerm
{
    public int NoOfMonths { get; init; }

    public LeaseTerm(int noOfMonths)
    {
        Assert(noOfMonths > 0);

        NoOfMonths = noOfMonths;
    }

    public static LeaseTerm OfMonths(int noOfMonths) 
        => new(noOfMonths);

    public static LeaseTerm OfYears(int noOfYears)
        => OfMonths(noOfYears * 12);
}
