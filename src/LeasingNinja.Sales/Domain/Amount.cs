using System;
using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public readonly record struct Amount(long AmountInCents, Currency Currency)
    {
        public static Amount Of(decimal amount, Currency currency)
            => OfCents((long) Math.Round(amount * 100), currency);

        public static Amount OfCents(long amountInCents, Currency currency)
            => new Amount(amountInCents, currency);

        public double AmountValue
            => AmountInCents / 100d;

        public override string ToString()
            => Currency + " " + AmountValue;
    }
}
