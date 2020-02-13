using LeasingNinja.Sales.Domain;

namespace LeasingNinja.Sales.Application
{
    public class ViewContract
    {
        private readonly Contracts _contracts;

        public ViewContract(Contracts contracts)
        {
            _contracts = contracts;
        }

        public Contract With(ContractNumber number)
        {
		    return _contracts.With(number);
        }
    }
}