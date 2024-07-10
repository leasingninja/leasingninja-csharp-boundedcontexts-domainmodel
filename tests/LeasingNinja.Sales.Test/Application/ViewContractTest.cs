using LeasingNinja.Sales.Domain;
using Moq;
using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Application;

public class ViewContractTest
{
    private readonly Mock<Contracts> _contractsMock;

    private readonly ViewContract _viewContractUnderTest;

    public ViewContractTest()
    {
        _contractsMock = new Mock<Contracts>();
        _viewContractUnderTest = new ViewContract(_contractsMock.Object);
    }

    [Fact]
    void GivenAContract_WhenViewContract_ThenContractIsReturned()
    {
        // Given
        _contractsMock.Setup(contracts => contracts
                .With(ContractNumber.Of("4711")))
            .Returns(new Contract(
                ContractNumber.Of("4711"),
                Customer.Of("Bob Smith"),
                Car.Of("Mercedes Benz E class"),
                Amount.Of(10_000, Currency.EUR)));

        // When
        Contract contract = _viewContractUnderTest.With(ContractNumber.Of("4711"));

        // Then
        Check.That(contract).HasFieldsWithSameValues(
            new Contract(
                ContractNumber.Of("4711"),
                Customer.Of("Bob Smith"),
                Car.Of("Mercedes Benz E class"),
                Amount.Of(10_000, Currency.EUR)));
    }

}
