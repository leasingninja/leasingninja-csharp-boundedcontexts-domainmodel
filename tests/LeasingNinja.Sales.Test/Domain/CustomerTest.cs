using NFluent;
using Xunit;

namespace LeasingNinja.Sales.Domain;

public class CustomerTest
{
    [Fact]
    void givenAStringWithOnlyLetters_whenIsValid_thenTrue()
    {
        // given
        var nameString = "John";

        // when
        bool isValid = Customer.IsValid(nameString);

        // then
        Check.That(isValid).IsTrue();
    }

    [Fact]
    void givenAStringWithNonStandardLatinCharacter_whenIsValid_thenTrue()
    {
        // given
        var nameString = "Björn";

        // when
        bool isValid = Customer.IsValid(nameString);

        // then
        Check.That(isValid).IsTrue();
    }

    [Fact]
    void givenAStringWithOnlyLettersAndSpace_whenIsValid_thenTrue()
    {
        // given
        var nameString = "John Buyer";

        // when
        bool isValid = Customer.IsValid(nameString);

        // then
        Check.That(isValid).IsTrue();
    }

    [Fact]
    void givenAStringWithNonStandardLatinCharacterAndSpace_whenIsValid_thenTrue()
    {
        // given
        var nameString = "John le Carré";

        // when
        bool isValid = Customer.IsValid(nameString);

        // then
        Check.That(isValid).IsTrue();
    }

    [Fact]
    void givenAStringWithNumbers_whenIsValid_thenFalse()
    {
        // given
        var nameString = "John42";

        // when
        bool isValid = Customer.IsValid(nameString);

        // then
        Check.That(isValid).IsFalse();
    }
}
