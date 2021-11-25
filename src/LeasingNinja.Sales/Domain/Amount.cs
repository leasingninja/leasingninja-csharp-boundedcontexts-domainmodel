using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public readonly struct Amount
    {
        public decimal AmountValue { get; }
        public string Currency { get; }

        private Amount(decimal amount, string currency) : this()
        {
            AmountValue = amount;
            Currency = currency;
        }

        public static Amount Of(decimal amount, string currency) {
            //assert currency != null;
		
            return new Amount(amount, currency);
        }
    }
}