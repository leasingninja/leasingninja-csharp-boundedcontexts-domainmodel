using System;
using System.Diagnostics;
using NMolecules.DDD;
using dddbits.Basetypes;
using static System.Diagnostics.Contracts.Contract;

namespace LeasingNinja.Sales.Domain
{
    [Entity]
    public class Contract : Entity<ContractNumber>
    {
        public ContractNumber Number => Identity;

        public Customer Lessee { get; }
        
        public Car Car { get; }
        
        public Amount Price { get; }
        
        //public SignDate SignDate { get; private set; }
        private SignDate? _signDate;

        //assert isSigned();
        public SignDate SignDate => _signDate!;

        public bool IsSigned => _signDate != null;


        //[Factory]
        public static Contract Restore(ContractNumber number, Customer lessee, Car car, Amount price, SignDate? signDate) {
            var contract = new Contract(number, lessee, car, price) {_signDate = signDate}; // TODO: set SignDatemdirectly here or replay with sign() ?

            return contract;
        }
	
        public Contract(ContractNumber number, Customer lessee, Car car, Amount price) : base(number)
        {
            Lessee = lessee;
            Car = car;
            Price = price;
        }

        // public void Sign(SignDate date)
        // {
        //     Requires(!IsSigned);
        //     Ensures(IsSigned);
        //
        //     _signDate = date;
        // }
        
        public void Sign(SignDate date)
        {
           if (IsSigned) 
           {
                throw new InvalidOperationException("Precondition violated: !IsSigned");
           }

           _signDate = date;

           Debug.Assert(IsSigned);
        }
        
    }
}