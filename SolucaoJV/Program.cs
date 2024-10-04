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
                .AddSingleton<Tabuleiro>()
                .AddSingleton<ConfiguraTela>()
                .AddSingleton<PartidaDomainService>()
                .AddSingleton<PartidaController>()
                .AddSingleton<IPartidaService, PartidaAppService>()
                .BuildServiceProvider();

            var configuraTela = serviceProvider.GetService<ConfiguraTela>();
            var partidaAppService = serviceProvider.GetService<PartidaAppService>();
            var ipartidaService = serviceProvider.GetService<IPartidaService>();
            var partidaController = serviceProvider.GetRequiredService<PartidaController>();

            configuraTela.ViewTela();
            ipartidaService.IniciarPartida();
        }
    }
}
