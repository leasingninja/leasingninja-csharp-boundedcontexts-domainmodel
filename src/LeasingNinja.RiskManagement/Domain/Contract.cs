using static System.Diagnostics.Debug;

using NMolecules.DDD;

using LeasingNinja.RiskManagement.Domain;

namespace LeasingNinja.Sales.Domain;

[Entity]
public class Contract
{
    [Identity]
    public ContractNumber Number { get; }

    private CreditRating CreditRating { get; set; }
    private VoteResult VoteResult { get; set; }

    public Contract(
        ContractNumber number,
        SignDate signDate // TODO: do we need the signDate?
    ) : this(number)
    {
    }

    public Contract(ContractNumber number)
    {
        Number = number;
    }

    public static Contract Restore(ContractNumber number, SignDate signDate, CreditRating rating, VoteResult voteResult)
    {
        var restoredContract = new Contract(number, signDate)
        {
            CreditRating = rating,
            VoteResult = voteResult,
        };

        return restoredContract;
    }

    public void CheckCreditRating(CreditRating rating)
    {
        CreditRating = rating;

        Assert(IsRated());
    }

    public bool IsRated()
    {
        return CreditRating != default;
    }

    public CreditRating Rating()
    {
        Assert(IsRated(), "Precondition violated: isRated()");

        return CreditRating;
    }

    public void Vote(VoteResult result)
    {
        Assert(IsRated()); // TODO: Decide DbC-Mechanism

        VoteResult = result;

        Assert(IsVoted());
    }

    public bool IsVoted()
    {
        return VoteResult != default;
    }

    public VoteResult VotingResult()
    {
        Assert(IsVoted());

        return VoteResult;
    }

    // TODO: equals() and hashCode()
}
