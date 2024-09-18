using static System.Diagnostics.Debug;

using System.Collections.Generic;
using NMolecules.DDD;
using System;

namespace LeasingNinja.Sales.Domain;

[Entity]
public class Contract
{
    [Identity]
    public ContractNumber Number { get; }

    public Customer Lessee { get; }
    public Car Car { get; }
    public Amount Price { get; }

    private record Calculation(LeaseTerm LeaseTerm, Interest Interest, Amount Installment);
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
            return _signDate!.Value;
        }
    }

    public Contract(ContractNumber number, Customer lessee, Car car, Amount price)
    {
        Number = number;
        Lessee = lessee;
        Car = car;
        Price = price;
    }

    public void CalculateInstallmentFor(LeaseTerm leaseTerm, Interest interest)
    {
        Assert(!IsSigned);

        double inAdvance = 0.0;
        double residualValue = 0.0;

        double pmt = FinancialCalculator.Pmt(
            leaseTerm.NoOfMonths,
            interest.PerMonth,
            -1 * Convert.ToDouble(Price.AmountValue),
            residualValue,
            inAdvance);

        _calculation = new Calculation(leaseTerm, interest, Amount.Of(Convert.ToDecimal(pmt), Price.Currency));

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

    public override string ToString()
    {
        return "Contract [number=" + Number + ", lessee=" + Lessee + ", car=" + Car
               + ", price=" + Price + ", signDate=" + SignDate + "]";
    }

    private bool Equals(Contract other)
    {
        return EqualityComparer<ContractNumber>.Default.Equals(Number, other.Number);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Contract) obj);
    }

    public override int GetHashCode()
    {
        return Number.GetHashCode();
    }
}
