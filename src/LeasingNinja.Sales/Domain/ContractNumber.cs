using dddbits.Attributes;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public readonly struct ContractNumber
    {
        private ContractNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static ContractNumber Of(string value) => new ContractNumber(value);
    }
}