using static System.Diagnostics.Debug;

using NMolecules.DDD;

namespace LeasingNinja.RiskManagement.Domain
{
    [ValueObject]
    public readonly record struct CreditRating(uint value)
    {
        // TODO:
        // public CreditRating(uint value)
        // {
        //     Assert(IsValid(value));
        //     this.value = value;
        // }

        public static bool IsValid(uint value)
            => value >= 1 && value <= 10;

        public static CreditRating Of(uint value)
            => new CreditRating(value);
    }
}

