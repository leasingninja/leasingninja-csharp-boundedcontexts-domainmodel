using static System.Diagnostics.Debug;

using NMolecules.DDD;
using dddbits.Basetypes;
using System;

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

    	private record Calculation(LeaseTerm LeaseTerm, Interest Interest, Amount Installment) {}
        private Calculation? _calculation;
        public bool IsCalculated => _calculation != null;
        public LeaseTerm LeaseTerm
        {
            get
            {
                Assert(IsCalculated);
                return _calculation!.LeaseTerm;
            }
        }

        public Interest Interest
        {
            get
            {
                Assert(IsCalculated);
                return _calculation!.Interest;
            }
        }

        public Amount Installment
        {
            get
            {
                Assert(IsCalculated);
                return _calculation!.Installment;
            }
        }


        private SignDate? _signDate;
        public bool IsSigned => _signDate != null;
        public SignDate SignDate
        {
            get
            {
                Assert(IsSigned);
                return _signDate!;
            }
        }



        //[Factory]
        public static Contract Restore(ContractNumber number, Customer lessee, Car car, Amount price, LeaseTerm? leaseTerm, Interest? interest, SignDate? signDate)
        {
            var contract = new Contract(number, lessee, car, price);
            if (leaseTerm != null && interest != null)
            {
                contract.CalculateInstallmentFor(leaseTerm, interest);
            }
            if(signDate != null)
            {
                contract.Sign(signDate);
            }

            return contract;
        }

        public Contract(ContractNumber number, Customer lessee, Car car, Amount price) : base(number)
        {
            Lessee = lessee;
            Car = car;
            Price = price;
        }

        public void CalculateInstallmentFor(LeaseTerm leaseTerm, Interest interest)
        {
            Assert(!IsSigned);

            double inAdvance = 0;
            double residualValue = 0;

            double pmt = FinancialCalculator.pmt(
                leaseTerm.NoOfMonths,
                interest.PerMonth,
                -1 * Price.AmountValue,
                residualValue,
                inAdvance);

            _calculation = new Calculation(leaseTerm, interest, Amount.Of((decimal) pmt, Price.Currency));

            Assert(IsCalculated);
        }

        public void Sign(SignDate date)
        {
            Assert(!IsSigned);
            Assert(IsCalculated);

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
