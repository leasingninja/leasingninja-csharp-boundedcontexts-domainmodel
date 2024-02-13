using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public readonly record struct ContractNumber(string Value)
    {
        public static ContractNumber Of(string value) => new(value);
    }
}
