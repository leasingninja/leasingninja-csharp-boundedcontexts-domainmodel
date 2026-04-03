using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain;

public class ContractTest
{
    [Fact]
    void GivenAFilledOutContract_whenCalculate_thenInstallmentIsX()
    {
        // given
        var contract = new Contract(ContractNumber.Of("4711"),
            Customer.Of("John Buyer"),
            Car.Of("Volkswagen ID.3"),
            Amount.Of(40_000, Currency.EUR));

        // when
        contract.CalculateInstallmentFor(LeaseTerm.OfMonths(48), Interest.Of(3.7));

        // then
        Check.That(contract.IsCalculated).IsTrue();
        Check.That(contract.LeaseTerm).IsEqualTo(LeaseTerm.OfMonths(48));
        Check.That(contract.Interest).IsEqualTo(Interest.Of(3.7));
        Check.That(contract.Installment).IsEqualTo(Amount.Of(897.80m, Currency.EUR));
    }

    [Fact]
    void GivenAFilledOutContractWith0Interest_whenCalculate_thenInstallmentIsX()
    {
        // given
        var contract = new Contract(ContractNumber.Of("4711"),
            Customer.Of("John Buyer"),
            Car.Of("Volkswagen ID.3"),
            Amount.Of(40_000, Currency.EUR));

        // when
        contract.CalculateInstallmentFor(LeaseTerm.OfMonths(48), Interest.Of(0));

        // then
        Check.That(contract.IsCalculated).IsTrue();
        Check.That(contract.Installment).IsEqualTo(Amount.Of(833.33m, Currency.EUR));
    }

    [Fact]
    void GivenACalculatedContract_whenSign_thenContractIsSigned()
    {
        // given
        var contract = new Contract(ContractNumber.Of("4711"),
            Customer.Of("John Buyer"),
            Car.Of("Mercedes Benz C-Class"),
            Amount.Of(20_000, Currency.EUR));
        contract.CalculateInstallmentFor(LeaseTerm.OfMonths(48), Interest.Of(3.7));

        // when
        contract.Sign(SignDate.Of(2018, 12, 24));

        // then
        Check.That(contract.IsSigned).IsTrue();
        Check.That(contract.SignDate).IsEqualTo(SignDate.Of(2018, 12, 24));
        // check that event ContractSigned is fired
    }

    [Fact]
    void GivenTwoContractsWithSameIdButDifferentFields_whenEquals_thenShouldReturnTrue()
    {
        // given
        var contract1 = new Contract(ContractNumber.Of("4711"),
                Customer.Of("John Buyer"),
                Car.Of("Mercedes Benz C-Class"),
                Amount.Of(40_000, Currency.EUR));
        var contract2 = new Contract(ContractNumber.Of("4711"),
                Customer.Of("Bob Myers"),
                Car.Of("Volkswagen ID.3"),
                Amount.Of(30_000, Currency.EUR));

        // when
        var equal = contract1.Equals(contract2);

        // then
        Check.That(equal).IsTrue();
    }

    [Fact]
    void GivenTwoContractsWithDifferentIdButSameFields_whenEquals_thenShouldReturnFalse()
    {
        // given
        var contract1 = new Contract(ContractNumber.Of("4711"),
                Customer.Of("John Buyer"),
                Car.Of("Mercedes Benz C-Class"),
                Amount.Of(40_000, Currency.EUR));
        var contract2 = new Contract(ContractNumber.Of("4712"),
                Customer.Of("John Buyer"),
                Car.Of("Mercedes Benz C-Class"),
                Amount.Of(40_000, Currency.EUR));

        // when
        var equal = contract1.Equals(contract2);

        // then
        Check.That(equal).IsFalse();
    }

    [Fact]
    void GivenTwoContractsWithSameId_whenHashcode_thenShouldBeEqual()
    {
        // given
		var contract1 = new Contract(ContractNumber.Of("4711"),
				Customer.Of("John Buyer"),
				Car.Of("Mercedes Benz C-Class"),
				Amount.Of(40_000, Currency.EUR));
        var contract2 = new Contract(ContractNumber.Of("4711"),
				Customer.Of("Bob Myers"),
				Car.Of("Volkswagen ID.3"),
				Amount.Of(30_000, Currency.EUR));

		// when
		var hashcode1 = contract1.GetHashCode();
		var hashcode2 = contract2.GetHashCode();

		// then
		Check.That(hashcode1).IsEqualTo(hashcode2);
    }
}
