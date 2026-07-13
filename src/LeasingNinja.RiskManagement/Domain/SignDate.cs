using NMolecules.DDD;

namespace LeasingNinja.RiskManagement.Domain;

[ValueObject]
public readonly record struct SignDate(int Year, int Month, int Day)
{
    public static SignDate Of(int year, int month, int day)
        => new(year, month, day);
}