using NMolecules.DDD.Attributes;

namespace LeasingNinja.Sales.Domain
{
    [Factory]
    public class ContractFactory
    {
        public static Contract RestoreContract(ContractNumber number, Customer lessee, Car car, Amount price, LeaseTerm? leaseTerm, Interest? interest, SignDate? signDate)
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
    }
}
