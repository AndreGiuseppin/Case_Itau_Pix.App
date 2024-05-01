using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using Case_Itau_Pix.Business.Interfaces.Services;
using Case_Itau_Pix.Business.Models;
using Case_Itau_Pix.Business.Services.TransferDecorator;
using Case_Itau_Pix.Tests.Attributes;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Case_Itau_Pix.Tests.Business.Services.TransferDecorator
{
    public class TransferWithBalanceTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void TransferWithBalanceTests_GuardClause(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(TransferWithBalance).GetConstructors());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Transfer_WhenSenderDontHaveBalance_ShoudlLogError
            (
            [Frozen] IBalanceService balanceService,
            TransferWithBalance sut,
            Transaction transaction,
            Balance balance
            )
        {
            transaction.TransactionValue = 1000;
            balance.AvailableBalance = 100;

            balanceService.GetBalance(transaction.SenderAccount)
                .Returns(balance);

            sut.Transfer(transaction);

            balanceService.Received(1).GetBalance(transaction.SenderAccount);
            balanceService.DidNotReceive().GetBalance(transaction.RecipientAccount);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Transfer_WhenSenderDontHaveBalance_ShoudlThrowException
            (
            [Frozen] IBalanceService balanceService,
            TransferWithBalance sut,
            Transaction transaction,
            Balance balance,
            Exception exception
            )
        {
            transaction.TransactionValue = 1000;
            balance.AvailableBalance = 100;

            balanceService.GetBalance(transaction.SenderAccount)
                .Throws(exception);

            sut.Transfer(transaction);

            balanceService.Received(1).GetBalance(transaction.SenderAccount);
            balanceService.DidNotReceive().GetBalance(transaction.RecipientAccount);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Transfer_WhenSenderHaveBalance_ShoudlCallNext
            (
            [Frozen] IBalanceService balanceService,
            TransferWithBalance sut,
            Transaction transaction,
            Balance balance
            )
        {
            transaction.TransactionValue = 1000;
            balance.AvailableBalance = 1500;

            balanceService.GetBalance(transaction.SenderAccount)
                .Returns(balance);

            sut.Transfer(transaction);

            balanceService.Received(1).GetBalance(transaction.SenderAccount);
            balanceService.Received(1).GetBalance(transaction.RecipientAccount);
        }
    }
}
