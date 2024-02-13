using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain;

public class ContractFactoryTest
{
    [Fact]
    void given_whenRestore_thenContractContainsRestoredData() {
        // given

        // when
        Contract contract = ContractFactory.RestoreContract(
            ContractNumber.Of("4711"),
            Customer.Of("John Buyer"),
            Car.Of("Mercedes Benz C-Class"),
            Amount.Of(20_000, Currency.EUR),
            LeaseTerm.OfMonths(48),
            Interest.Of(3.6),
            SignDate.Of(2018, 04, 12));

        // then
        Check.That(contract.Number).IsEqualTo(ContractNumber.Of("4711"));
        Check.That(contract.Lessee).IsEqualTo(Customer.Of("John Buyer"));
        Check.That(contract.Car).IsEqualTo(Car.Of("Mercedes Benz C-Class"));
        Check.That(contract.Price).IsEqualTo(Amount.Of(20_000, Currency.EUR));
        Check.That<bool>(contract.IsCalculated).IsTrue();
        Check.That<bool>(contract.IsSigned).IsTrue();
        // check that event ContractSigned is fired
    }
}