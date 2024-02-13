using static System.Diagnostics.Debug;

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
            => new(amountInCents, currency);

        public static Amount operator +(Amount amount1, Amount amount2)
        {
            Assert(amount1.Currency == amount2.Currency);

            return OfCents(amount1.AmountInCents + amount2.AmountInCents, amount1.Currency);
        }

        public static Amount operator -(Amount amount1, Amount amount2)
        {
            Assert(amount1.Currency == amount2.Currency);

            return OfCents(amount1.AmountInCents - amount2.AmountInCents, amount1.Currency);
        }

        public double AmountValue
            => AmountInCents / 100d;

        public override string ToString()
            => Currency + " " + AmountValue;
    }
}
