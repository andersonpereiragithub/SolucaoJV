using Microsoft.Extensions.DependencyInjection;
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
                .AddSingleton<PartidaAppService>()
                .BuildServiceProvider();

            var configuraTela = serviceProvider.GetService<ConfiguraTela>();
            var partidaAppService = serviceProvider.GetService<PartidaAppService>();
            var partidaController = serviceProvider.GetRequiredService<PartidaController>();

            configuraTela.ViewTela();
            partidaAppService.IniciarPartida();

            //Tabuleiro tabuleiro = new Tabuleiro();
            //ConfiguraTela configura = new ConfiguraTela();
            
            //configura.ViewTela();

            //PartidaDomainService partidaDomainService = new PartidaDomainService();

            //PartidaAppService partidaAppService = new PartidaAppService(tabuleiro, partidaDomainService);
            
            //partidaAppService.IniciarPartida();
        }
    }
}
