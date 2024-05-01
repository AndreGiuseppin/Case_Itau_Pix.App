using Case_Itau_Pix.Business.Interfaces.Services;
using Case_Itau_Pix.Business.Models;
using Microsoft.Extensions.Logging;

namespace Case_Itau_Pix.Business.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly ILogger _logger;
        private readonly IEnumerable<Balance> _balances;

        public BalanceService(ILogger<BalanceService> logger, IEnumerable<Balance> balances)
        {
            if (balances is null)
                throw new ArgumentNullException(nameof(balances));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            Balance balance = new();
            _balances = balance.PopulateModel();
        }

        public Balance GetBalance(string account)
        {
            try
            {
                Balance balance = new();
                var response = balance.GetBalance(account, _balances);

                if (response is null)
                {
                    _logger.LogError("{service_name} - Account {account} does not exist", "GetBalance", account);
                    return new Balance();
                }

                return response;
            }
            catch (Exception e)
            {
                _logger.LogError("{service_name} - An error occur. Error: {error}", "GetBalance", e.Message);
                return new Balance();
            }
        }
    }
}