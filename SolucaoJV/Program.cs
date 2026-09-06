using Microsoft.Extensions.DependencyInjection;
using SolucaoJV.Application.Interfaces;
using SolucaoJV.Application.Services;
using SolucaoJV.Domain.Services;
using SolucaoJV.UI.Views;
using SolucaoJV.UI.Controllers;
using System;
using SolucaoJV.Domain.ValueObjects;

namespace SolucaoJV.V
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()

               .AddSingleton<Tabuleiro>()
               .AddSingleton<ConfiguraTela>()
               .AddSingleton<Posicao>()
               .AddSingleton<JogadaService>()
               .AddSingleton<PartidaDomainService>()
               .AddSingleton<IPartidaAppService, PartidaAppService>()
               .AddSingleton<IMensagemService, MensagemService>()

               .BuildServiceProvider();

            var ipartidaService = serviceProvider.GetRequiredService<IPartidaAppService>();
            
            ipartidaService.IniciarPartida();
        }
    }
}
