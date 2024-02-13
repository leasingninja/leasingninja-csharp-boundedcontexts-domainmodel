using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public readonly record struct SignDate(int Year, int Month, int Day)
    {
        public static SignDate Of(in int year, in int month, in int day)
            => new(year, month, day);
    }
}
