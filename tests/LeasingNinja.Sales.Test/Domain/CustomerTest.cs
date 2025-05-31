using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain;

public class CustomerTest
{
    [Fact]
    void GivenAStringWithOnlyLetters_whenIsValid_thenTrue()
    {
        // given
        var nameString = "John";

        // when
        bool isValid = Customer.IsValid(nameString);

        // then
        Check.That(isValid).IsTrue();
    }

    [Fact]
    void GivenAStringWithNonStandardLatinCharacter_whenIsValid_thenTrue()
    {
        // given
        var nameString = "Björn";

        // when
        bool isValid = Customer.IsValid(nameString);

        // then
        Check.That(isValid).IsTrue();
    }

    [Fact]
    void GivenAStringWithOnlyLettersAndSpace_whenIsValid_thenTrue()
    {
        // given
        var nameString = "John Buyer";

        // when
        bool isValid = Customer.IsValid(nameString);

        // then
        Check.That(isValid).IsTrue();
    }

    [Fact]
    void GivenAStringWithNonStandardLatinCharacterAndSpace_whenIsValid_thenTrue()
    {
        // given
        var nameString = "John le Carré";

        // when
        bool isValid = Customer.IsValid(nameString);

        // then
        Check.That(isValid).IsTrue();
    }

    [Fact]
    void GivenAStringWithNumbers_whenIsValid_thenFalse()
    {
        // given
        var nameString = "John42";

        // when
        bool isValid = Customer.IsValid(nameString);

        // then
        Check.That(isValid).IsFalse();
    }
}
