using Xunit;
using NFluent;

using LeasingNinja.Sales.Domain;

namespace LeasingNinja.RiskManagement.Domain;

public class ContractTest
{
    [Fact]
    void GivenASignedContract_whenCheckCreditRating_ThenRated()
    {
        // given
        var contract = new Contract(ContractNumber.Of("4711"), SignDate.Of(2018, 4, 1));

        // when
        contract.CheckCreditRating(CreditRating.Of(3));

        // then
        Check.That(contract.IsRated()).IsTrue();
        Check.That(contract.Rating()).IsEqualTo(CreditRating.Of(3));
    }

    [Fact]
    void GivenARatedContract_whenVote_ThenVoted()
    {
        // given
        var contract = new Contract(ContractNumber.Of("4711"), SignDate.Of(2018, 4, 1));
        contract.CheckCreditRating(CreditRating.Of(3));

        // when
        contract.Vote(VoteResult.ACCEPTED);

        // then
        Check.That(contract.IsVoted()).IsTrue();
    }

    [Fact]
    void RestoreContract()
    {
        // given

        // when
        var contract = Contract.Restore(
                ContractNumber.Of("4711"),
                SignDate.Of(2018, 4, 1),
                CreditRating.Of(3),
                VoteResult.ACCEPTED_WITH_OBLIGATIONS);

        // then
        Check.That(contract.Number).IsEqualTo(ContractNumber.Of("4711"));
//		Check.That(contract.SignDate()).IsEqualTo(SignDate.Of(2018, 4, 1));
		Check.That(contract.Rating()).IsEqualTo(CreditRating.Of(3));
		Check.That(contract.IsVoted()).IsTrue();
    }
}
