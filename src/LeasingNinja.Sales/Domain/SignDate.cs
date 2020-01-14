using dddbits.Attributes;
using dddbits.Basetypes;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public sealed class SignDate : TinyDateValue
    {
        public static SignDate Of(in int year, in int month, in int day)
        {
           return new SignDate(year, month, day);
        }

        private SignDate(in int year, in int month, in int day) : base(in year, in month, in day)
        {
        }
    }
}