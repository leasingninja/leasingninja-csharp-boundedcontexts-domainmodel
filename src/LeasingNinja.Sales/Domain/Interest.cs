using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain
{
    /**
     * Interest in percent.
     */
    [ValueObject]
    public record Interest(double PerYear)
    {
        public static Interest Of(double perYear)
            => new Interest(perYear);

        public double PerMonth => PerYear / 12;
    }
}
