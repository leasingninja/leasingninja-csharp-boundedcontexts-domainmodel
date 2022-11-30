using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public readonly record struct Customer(string Name)
    {
        public static Customer Of(string name) => new Customer(name);
    }
}
