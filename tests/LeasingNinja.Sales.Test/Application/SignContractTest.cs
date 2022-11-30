using LeasingNinja.Sales.Domain;
using Moq;
using Xunit;

namespace LeasingNinja.Sales.Application
{
    public class SignContractTest
    {
        private readonly Mock<Contracts> _contractsMock;

        //private InboxApplicationService inboxApplicationServiceMock;

        private SignContract _signContractUnderTest;

        public SignContractTest()
        {
            _contractsMock = new Mock<Contracts>();
            _signContractUnderTest = new SignContract(_contractsMock.Object);
        }

        [Fact]
        void GivenAContract_WhenSign_ThenSignedContractIsSaved()
        {
            // Given
            var contract = new Contract(
                ContractNumber.Of("4711"),
                Customer.Of("Bob Smith"),
                Car.Of("Mercedes Benz E-Class"),
                Amount.Of(10_000, Currency.EUR));
            contract.CalculateInstallmentFor(LeaseTerm.OfMonths(48), Interest.Of(3.7));
            _contractsMock
                .Setup(contracts => contracts.With(ContractNumber.Of("4711")))
                .Returns(contract);

            // When
            _signContractUnderTest.With(
                ContractNumber.Of("4711"),
//				"2018-04-12");
                SignDate.Of(2018, 4, 12));

            // Then
            //then(contractsMock).should().save(refEq(Contract.restore(
            _contractsMock
                .Verify(contracts => contracts.Save(
                    ContractFactory.RestoreContract(
                        ContractNumber.Of("4711"),
                        Customer.Of("Bob Smith"),
                        Car.Of("Mercedes Benz E-Class"),
                        Amount.Of(10_000,  Currency.EUR),
                        LeaseTerm.OfMonths(48),
                        Interest.Of(3.7),
                        SignDate.Of(2018, 04, 12))));
            //then(inboxApplicationServiceMock).should().confirmSignedContract("4711", 2018, 04, 12);
        }

    }
}
