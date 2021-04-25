using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain
{
    [Repository]
    public interface Contracts
    {
        Contract With(ContractNumber number);

        void Save(Contract contract);        
    }
}