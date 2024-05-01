using Microsoft.Extensions.Logging;

namespace Case_Itau_Pix.App.Extensions.Logging
{
    public static class Logging
    {
        public static ILoggingBuilder AddILogger(this ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddConsole();

            return loggingBuilder;
        }
    }
}