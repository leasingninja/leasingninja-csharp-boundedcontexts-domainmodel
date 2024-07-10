using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain;

/**
 * Interest in percent.
 */
[ValueObject]
public readonly record struct Interest(double PerYear)
{
    public static Interest Of(double perYear) => new(perYear);

    public double PerMonth => PerYear / 12;
}
