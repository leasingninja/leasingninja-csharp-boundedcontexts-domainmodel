using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public readonly record struct Amount(decimal AmountValue, string Currency)
    {
        public static Amount Of(decimal amount, string currency) => new Amount(amount, currency);
    }
}