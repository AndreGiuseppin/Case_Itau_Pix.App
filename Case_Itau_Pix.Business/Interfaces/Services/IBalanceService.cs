using Case_Itau_Pix.Business.Models;

namespace Case_Itau_Pix.Business.Interfaces.Services
{
    public interface IBalanceService
    {
        Balance GetBalance(string account);
    }
}
