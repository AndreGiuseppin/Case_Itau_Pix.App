using Case_Itau_Pix.Business.Interfaces.Services.TransferDecorator;
using Case_Itau_Pix.Business.Models;
using Microsoft.Extensions.Logging;

namespace Case_Itau_Pix.Business.Services.TransferDecorator
{
    public class TransferWithResult : ITransfer
    {
        private readonly ILogger _logger;

        public TransferWithResult(ILogger<TransferWithBalance> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Transfer(Transaction transaction)
        {
            try
            {
                if (transaction.HasError)
                    return;

                transaction.SenderBalance.AvailableBalance -= transaction.TransactionValue;
                transaction.RecipientBalance.AvailableBalance += transaction.TransactionValue;

                _logger.LogInformation("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}",
                    transaction.CorrelationId, transaction.SenderBalance.AvailableBalance, transaction.RecipientBalance.AvailableBalance);

                return;
            }
            catch (Exception e)
            {
                _logger.LogError("{service_name} - An error occurs. Error: {error}", "TransferWithResult", e.Message);
                return;
            }
        }
    }
}
