using Case_Itau_Pix.Business.Interfaces.Services.TransferDecorator;
using Case_Itau_Pix.Business.Models;
using Microsoft.Extensions.Logging;

namespace Case_Itau_Pix.Business.Services.TransferDecorator
{
    public class TransferWithTransactions : ITransfer
    {
        private readonly ITransfer _next;
        private readonly ILogger _logger;

        public TransferWithTransactions(ITransfer next, ILogger<TransferWithTransactions> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Transfer(Transaction transaction)
        {
            try
            {
                var transactions = transaction.PopulateModel();

                foreach (var item in transactions)
                {
                    _next.Transfer(item);
                }

                return;
            }
            catch (Exception e)
            {
                _logger.LogError("{service_name} - An error occurs. Error: {error}", "TransferWithTransactions", e.Message);
                return;
            }
        }
    }
}
