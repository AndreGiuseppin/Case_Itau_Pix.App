using Case_Itau_Pix.Business.Interfaces.Services;
using Case_Itau_Pix.Business.Interfaces.Services.TransferDecorator;
using Case_Itau_Pix.Business.Models;
using Microsoft.Extensions.Logging;

namespace Case_Itau_Pix.Business.Services.TransferDecorator
{
    public class TransferWithBalance : ITransfer
    {
        private readonly ITransfer _next;
        private readonly IBalanceService _balanceService;
        private readonly ILogger _logger;

        public TransferWithBalance(ITransfer next, IBalanceService balanceService, ILogger<TransferWithBalance> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _balanceService = balanceService ?? throw new ArgumentNullException(nameof(balanceService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Transfer(Transaction transaction)
        {
            try
            {
                var senderBalance = _balanceService.GetBalance(transaction.SenderAccount);

                if (senderBalance.AvailableBalance < transaction.TransactionValue)
                {
                    _logger.LogError("Transacao numero {0} foi cancelada por falta de saldo", transaction.CorrelationId);

                    transaction.WithError();

                    return;
                }

                var recipientBalance = _balanceService.GetBalance(transaction.RecipientAccount);

                transaction.WithSenderBalance(senderBalance);
                transaction.WithRecipientBalance(recipientBalance);

                _next.Transfer(transaction);

                return;
            }
            catch (Exception e)
            {
                _logger.LogError("{service_name} - An error occurs. Error: {error}", "TransferWithBalance", e.Message);
                return;
            }
        }
    }
}
