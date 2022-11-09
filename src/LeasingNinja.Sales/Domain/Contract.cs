using static System.Diagnostics.Debug;

using NMolecules.DDD;
using dddbits.Basetypes;

namespace LeasingNinja.Sales.Domain
{
    [Entity]
    public class Contract : Entity<ContractNumber>
    {
        [Identity]
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

        public void Sign(SignDate date)
        {
           Assert(!IsSigned); 

           _signDate = date;

           Assert(IsSigned);
        }

        //// Alternative 1: Exceptions
        // public void Sign(SignDate date)
        // {
        //     if (IsSigned) throw new InvalidOperationException("Precondition violated: !IsSigned");
        //
        //    _signDate = date;
        //
        //     if (!IsSigned) throw new InvalidOperationException("Precondition violated: !IsSigned");
        // }

        //// Alternative 2: CodeContracts
        //using static System.Diagnostics.Contracts.Contract;
        // public void Sign(SignDate date)
        // {
        //     Requires(!IsSigned);
        //     Ensures(IsSigned);
        //
        //     _signDate = date;
        // }
        
    }
}