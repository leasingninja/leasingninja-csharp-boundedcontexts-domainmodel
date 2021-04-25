using NMolecules.DDD;
using dddbits.Basetypes;

namespace LeasingNinja.Sales.Domain
{
    [ValueObject]
    public class Car : TinyStringValue
    {
        private Car(string name) : base(name)
        {
        }

        public static Car Of(string name) => new Car(name);
    }
}