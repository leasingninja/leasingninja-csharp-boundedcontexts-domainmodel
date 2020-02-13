using LeasingNinja.Sales.Domain;

namespace LeasingNinja.Sales.Application
{
    public class SignContract
    {
        private readonly Contracts _contracts;

        public SignContract(Contracts contracts)
        {
            _contracts = contracts;
        }

        public void With(ContractNumber number, SignDate signDate)
        {
            var contract = _contracts.With(number);
		
            contract.Sign(signDate);
		
            _contracts.Save(contract);
		
            //riskmanagementInbox.confirmSignedContract(number.value(), signDate.year(), signDate.month(), signDate.day());
        }
    }
}