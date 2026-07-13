
using NMolecules.Events;

namespace LeasingNinja.Sales.Domain;

[DomainEvent]
public record ContractSigned(ContractNumber contract, SignDate signDate)
{
}