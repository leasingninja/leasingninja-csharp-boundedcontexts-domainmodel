using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain;

[Factory]
public class ContractFactory
{
    public static Contract RestoreContract(ContractNumber number, Customer lessee, Car car, Amount price, LeaseTerm? leaseTerm, Interest? interest, SignDate? signDate)
    {
        var contract = new Contract(number, lessee, car, price);
        if (leaseTerm.HasValue && interest.HasValue)
        {
            contract.CalculateInstallmentFor(leaseTerm.Value, interest.Value);
        }
        if(signDate.HasValue)
        {
            contract.Sign(signDate.Value);
        }
        return contract;
    }
}
