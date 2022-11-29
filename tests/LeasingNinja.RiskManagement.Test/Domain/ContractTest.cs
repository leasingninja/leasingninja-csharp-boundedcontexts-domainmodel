using NFluent;
using Xunit;

namespace LeasingNinja.RiskManagement.Domain
{
    public class ContractTest
    {
/* TODO: translate from Java to C#
        [Fact]
        void givenASignedContract_whenCheckCreditRating_ThenRated() {
            // given
            var contract = new Contract(ContractNumber.of("4711"), SignDate.of(2018, 4, 1));

            // when
            contract.checkCreditRating(CreditRating.GOOD);

            // then
            assertThat(contract.isRated()).isTrue();
            assertThat(contract.rating()).isEqualTo(CreditRating.GOOD);
        }

        @Test
        void givenARatedContract_whenVote_ThenVoted() {
            // given
            var contract = new Contract(ContractNumber.of("4711"), SignDate.of(2018, 4, 1));
            contract.checkCreditRating(CreditRating.GOOD);

            // when
            contract.vote(VoteResult.ACCEPTED);

            // then
            assertThat(contract.isVoted()).isTrue();
        }

        @Test
        void restoreContract() {
            // given

            // when
            var contract = Contract.restore(
                ContractNumber.of("4711"),
                SignDate.of(2018, 4, 1),
                CreditRating.GOOD,
                VoteResult.ACCEPTED_WITH_OBLIGATIONS);

            // then
            assertThat(contract.identity()).isEqualTo(ContractNumber.of("4711"));
//		assertThat(contract.signDate()).isEqualTo(SignDate.of(2018, 4, 1));
            assertThat(contract.rating()).isEqualTo(CreditRating.GOOD);
            assertThat(contract.isVoted()).isTrue();
        }
*/
    }
}
