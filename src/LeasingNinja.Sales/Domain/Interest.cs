using static System.Diagnostics.Debug;

using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain;

/// <summary>
/// Interest in percent.
/// </summary>
[ValueObject]
public readonly record struct Interest
{
    public double PerYear { get; init; }

    public Interest(double perYear)
    {
        Assert(perYear >= 0);

        PerYear = perYear;
    }

    public static Interest Of(double perYear) => new(perYear);

    public double PerMonth => PerYear / 12;

    public override string ToString()
    {
        return "Interest [" + PerYear + "% p.a.]";
    }
}
