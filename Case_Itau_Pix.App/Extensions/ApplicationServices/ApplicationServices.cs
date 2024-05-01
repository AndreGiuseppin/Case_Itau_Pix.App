using Case_Itau_Pix.Business.Interfaces.Services;
using Case_Itau_Pix.Business.Interfaces.Services.TransferDecorator;
using Case_Itau_Pix.Business.Services;
using Case_Itau_Pix.Business.Services.TransferDecorator;
using Microsoft.Extensions.DependencyInjection;

namespace Case_Itau_Pix.App.Extensions.ApplicationServices
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IBalanceService, BalanceService>();

            service.AddScoped<ITransfer, TransferWithResult>();
            service.Decorate<ITransfer, TransferWithBalance>();
            service.Decorate<ITransfer, TransferWithTransactions>();

            return service;
        }
    }
}
