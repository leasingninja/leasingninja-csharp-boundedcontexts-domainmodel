using static System.Diagnostics.Debug;

using NMolecules.DDD;

namespace LeasingNinja.RiskManagement.Domain;

[ValueObject]
public readonly record struct CreditRating
{
    private readonly uint value;

    public CreditRating(uint value)
    {
        Assert(IsValid(value));
        
        this.value = value;
    }

    public static bool IsValid(uint value)
        => value is >= 1 and <= 10;

    public static CreditRating Of(uint value)
        => new(value);
}
