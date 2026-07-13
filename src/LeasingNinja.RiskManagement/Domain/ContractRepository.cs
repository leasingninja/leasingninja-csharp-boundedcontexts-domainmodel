using System.Collections.Generic;

using NMolecules.DDD;

using LeasingNinja.Sales.Domain;

namespace LeasingNinja.RiskManagement.Domain;

[Repository]
public interface ContractRepository
{
    Contract FindById(ContractNumber number);

	IList<Contract> FindAll();

	void Save(Contract contract);
}
