using LeasingNinja.Sales.Domain;
using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Infrastructure
{
    public class InMemoryContractsTest
    {
        private InMemoryContracts _contractsUnderTest;

        public InMemoryContractsTest()
        {
            _contractsUnderTest = new InMemoryContracts();
        }
	
        [Fact]
        void GivenEmtpyContracts_WhenContractSavedAndLoaded_ThenItIsAnEqualContract() {
            // given
		
            // when
            _contractsUnderTest.Save(new Contract(
                ContractNumber.Of("4711"),
                Customer.Of("John Buyer"),
                Car.Of("Mercedes Benz C class"),
                Amount.Of(20_000, "EUR")));
            var contract = _contractsUnderTest.With(ContractNumber.Of("4711"));
		
            // then
            Check.That(contract).HasFieldsWithSameValues(
                new Contract(
                    ContractNumber.Of("4711"),
                    Customer.Of("John Buyer"),
                    Car.Of("Mercedes Benz C class"),
                    Amount.Of(20_000, "EUR")));
        }
        
    }
}