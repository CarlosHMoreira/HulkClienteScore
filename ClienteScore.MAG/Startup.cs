using ClienteScore.MAG.Servicos;
using ClienteScoreMAG.Dominio.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ClienteScoreMAG.Startup))]

namespace ClienteScoreMAG
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IEmailServico, EmailServico>();
        }
    }
}
