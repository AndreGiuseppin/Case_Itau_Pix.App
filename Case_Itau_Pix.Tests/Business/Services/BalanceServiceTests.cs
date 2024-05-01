using AutoFixture.Idioms;
using Case_Itau_Pix.Business.Services;
using Case_Itau_Pix.Tests.Attributes;
using FluentAssertions;

namespace Case_Itau_Pix.Tests.Business.Services
{
    public class BalanceServiceTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void BalanceServiceTests_GuardClause(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(BalanceService).GetConstructors());
        }

        [Theory]
        [AutoNSubstituteData]
        public void GetBalance_WhenBalanceIsNull_ShouldLog
            (
            BalanceService sut
            )
        {
            var account = "dont exist";

            var result = sut.GetBalance(account);

            result.AvailableBalance.Should().Be(0);
            result.Account.Should().Be(string.Empty);
        }

        [Theory]
        [AutoNSubstituteData]
        public void GetBalance_WhenBalanceIsNotNull_ShouldL
            (
            BalanceService sut
            )
        {
            var account = "938485762";

            var result = sut.GetBalance(account);

            result.AvailableBalance.Should().Be(180);
            result.Account.Should().Be("938485762");
        }
    }
}
