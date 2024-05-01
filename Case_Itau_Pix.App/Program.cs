using Case_Itau_Pix.App.Extensions.ApplicationServices;
using Case_Itau_Pix.App.Extensions.Logging;
using Case_Itau_Pix.Business.Interfaces.Services.TransferDecorator;
using Case_Itau_Pix.Business.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddILogger();
builder.Services.AddServices();

using IHost host = builder.Build();
using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;
var balanceService = provider.GetRequiredService<ITransfer>();

Transaction transaction = new();
balanceService.Transfer(transaction);