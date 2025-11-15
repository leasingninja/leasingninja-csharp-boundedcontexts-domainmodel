using NMolecules.DDD;

namespace LeasingNinja.RiskManagement.Domain;

[ValueObject]
public readonly record struct ContractNumber(string number)
{
    public static ContractNumber Of(string contractNumber) => new ContractNumber(contractNumber);
}
