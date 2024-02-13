using System.Collections.Generic;
using LeasingNinja.Sales.Domain;

namespace LeasingNinja.Sales.Infrastructure;

public class InMemoryContracts : Contracts
{
    private readonly IDictionary<ContractNumber, Contract> _contracts;
	
    public InMemoryContracts() {
        _contracts = new Dictionary<ContractNumber, Contract>();
    }

    public Contract With(ContractNumber number)
    {
        return _contracts[number];
    }

    public void Save(Contract contract)
    {
        _contracts.Add(contract.Number, contract);
    }
}