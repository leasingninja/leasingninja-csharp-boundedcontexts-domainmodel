using dddbits.Attributes;
using dddbits.Basetypes;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public class Customer : TinyStringType
    {
        public static Customer Of(string customer) => new Customer(customer);

        private Customer(string customer) : base(customer)
        {
        }
    }
}