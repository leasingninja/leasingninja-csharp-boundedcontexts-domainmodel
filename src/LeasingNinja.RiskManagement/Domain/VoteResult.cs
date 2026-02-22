using NMolecules.DDD;

[ValueObject]
public enum VoteResult
{
	NOT_VOTED,
    ACCEPTED,
	ACCEPTED_WITH_OBLIGATIONS,
	REJECTED
}