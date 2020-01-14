using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain
{
    public class ContractTest
    { 
        [Fact]
        void givenANewContract_whenSign_thenContractIsSigned() {
            // given
            var contract = new Contract(ContractNumber.Of("4711"),
                Customer.Of("John Buyer"),
                Car.Of("Mercedes Benz C-Class"),
                Amount.Of(20_000, "EUR"));

            // when
            contract.Sign(SignDate.Of(2018, 12, 24));

            // then
            Check.That(contract.IsSigned).IsTrue();
            Check.That(contract.SignDate).IsEqualTo(SignDate.Of(2018, 12, 24));
            // check that event ContractSigned is fired
        }

        [Fact]
        void given_whenRestore_thenContractContainsRestoredData() {
            // given

            // when
            Contract contract = Contract.Restore(
                ContractNumber.Of("4711"),
                Customer.Of("John Buyer"),
                Car.Of("Mercedes Benz C-Class"),
                Amount.Of(20_000, "EUR"),
                SignDate.Of(2018, 04, 12));

            // then
            Check.That(contract.Number).IsEqualTo(ContractNumber.Of("4711"));
            Check.That(contract.Lessee).IsEqualTo(Customer.Of("John Buyer"));
            Check.That(contract.Car).IsEqualTo(Car.Of("Mercedes Benz C-Class"));
            Check.That(contract.Price).IsEqualTo(Amount.Of(20_000, "EUR"));
            Check.That<bool>(contract.IsSigned).IsTrue();
            // check that event ContractSigned is fired
        }
    }
}