using Case_Itau_Pix.Business.Models;

namespace Case_Itau_Pix.Business.Interfaces.Services.TransferDecorator
{
    public interface ITransfer
    {
        void Transfer(Transaction transaction);
    }
}
