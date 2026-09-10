using Microsoft.Extensions.DependencyInjection;
using SolucaoJV.Application.Interfaces;
using SolucaoJV.Application.Services;
using SolucaoJV.Domain.Services;
using SolucaoJV.UI.Views;
using SolucaoJV.UI.Controllers;
using System;

namespace SolucaoJV.V
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()

               .AddSingleton<ITabuleiro, Tabuleiro>()
               .AddSingleton<IConfiguraTela, ConfiguraTela>()
               .AddSingleton<IJogadaService, JogadaService>()
               .AddSingleton<PartidaDomainService>()
               .AddSingleton<IPartidaAppService, PartidaAppService>()
               .AddSingleton<IMensagemService, MensagemService>()
               .AddSingleton<IBoasVindas, ConsoleBoasVindas>()

               .BuildServiceProvider();

            var ipartidaService = serviceProvider.GetRequiredService<IPartidaAppService>();
            
            ipartidaService.IniciarPartida();
        }
    }
}
