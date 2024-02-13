using LeasingNinja.Sales.Domain;

namespace LeasingNinja.Sales.Application;

public class FilloutContract
{
    private readonly Contracts _contracts;

    public FilloutContract(Contracts contracts)
    {
        _contracts = contracts;
    }

    public void With(ContractNumber number, Customer customer, Car car, Amount amount)
    {
        _contracts.Save(new Contract(
            number,
            customer,
            car,
            amount));
    }
}