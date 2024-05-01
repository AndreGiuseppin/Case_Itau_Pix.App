using AutoFixture.Idioms;
using Case_Itau_Pix.Business.Models;
using Case_Itau_Pix.Business.Services.TransferDecorator;
using Case_Itau_Pix.Tests.Attributes;
using FluentAssertions;

namespace Case_Itau_Pix.Tests.Business.Services.TransferDecorator
{
    public class TransferWithResultTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void TransferWithResultTests_GuardClause(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(TransferWithResult).GetConstructors());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Transfer_WhenTransactionDotnHasError_ShouldTransfer
            (
            TransferWithResult sut,
            Transaction transaction
            )
        {
            transaction.TransactionValue = 20;
            transaction.WithSenderBalance(new Balance { AvailableBalance = 100 });
            transaction.WithRecipientBalance(new Balance { AvailableBalance = 100 });

            var initialSenderBalance = transaction.SenderBalance.AvailableBalance;
            var initialRecipientBalance = transaction.RecipientBalance.AvailableBalance;

            sut.Transfer(transaction);

            transaction.SenderBalance.AvailableBalance.Should().Be(80);
            transaction.RecipientBalance.AvailableBalance.Should().Be(120);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Transfer_WhenTransactionHasError_ShouldReturn
            (
            TransferWithResult sut,
            Transaction transaction
            )
        {
            transaction.WithSenderBalance(new Balance { AvailableBalance = 100 });
            transaction.WithRecipientBalance(new Balance { AvailableBalance = 200 });

            var initialSenderBalance = transaction.SenderBalance.AvailableBalance;
            var initialRecipientBalance = transaction.RecipientBalance.AvailableBalance;
            transaction.WithError();

            sut.Transfer(transaction);

            transaction.SenderBalance.AvailableBalance.Should().Be(initialSenderBalance);
            transaction.RecipientBalance.AvailableBalance.Should().Be(initialRecipientBalance);
        }
    }
}
