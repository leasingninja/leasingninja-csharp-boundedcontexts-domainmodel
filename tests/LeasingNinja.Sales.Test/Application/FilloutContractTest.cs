using LeasingNinja.Sales.Domain;
using Moq;
using Xunit;

namespace LeasingNinja.Sales.Application
{
    public class FilloutContractTest
    {
        private readonly Mock<Contracts> _contractsMock;

        private readonly FilloutContract _filloutContractUnderTest;

        public FilloutContractTest()
        {
            _contractsMock = new Mock<Contracts>();
            _filloutContractUnderTest = new FilloutContract(_contractsMock.Object);
        }

        [Fact]
        void GivenEmptyContract_WhenFillout_ThenSave()
        {
            // Given
            _contractsMock.Setup(contracts => contracts.Save(It.IsAny<Contract>()));

             // When
            _filloutContractUnderTest.With(
                ContractNumber.Of("4711"),
                Customer.Of("Bob Smith"),
                Car.Of("Mercedes Benz E-Class"),
                Amount.Of(10_000, Currency.EUR));


            // Then
            _contractsMock.Verify(contracts => contracts.Save(new Contract(
                ContractNumber.Of("4711"),
                Customer.Of("Bob Smith"),
                Car.Of("Mercedes Benz E-Class"),
                Amount.Of(10_000,  Currency.EUR))));
        }

    }
}
