using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain;

[ValueObject]
public readonly record struct Car(string Name)
{
    public static Car Of(string name) => new(name);
}