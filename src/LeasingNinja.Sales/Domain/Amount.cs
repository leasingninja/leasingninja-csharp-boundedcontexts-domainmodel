using dddbits.Attributes;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public readonly struct Amount
    {
        public int AmountValue { get; }
        public string Currency { get; }

        private Amount(int amount, string currency) : this()
        {
            AmountValue = amount;
            Currency = currency;
        }

        public static Amount Of(int amount, string currency) {
            //assert currency != null;
		
            return new Amount(amount, currency);
        }
    }
}