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
                .AddScoped<PartidaDomainService>()
                .AddScoped<IPartidaService, PartidaAppService>()
                .AddScoped<PartidaController>()
                .AddScoped<IMensagemService, MensagemService>()

                

                .BuildServiceProvider();

            //var tabuleiro = serviceProvider.GetServices<Tabuleiro>();
            //var configuraTela = serviceProvider.GetService<ConfiguraTela>();
            //var posicao = serviceProvider.GetService<Posicao>();
            //var partidaAppService = serviceProvider.GetService<PartidaAppService>();
             var ipartidaService = serviceProvider.GetService<IPartidaService>();
             var partidaController = serviceProvider.GetRequiredService<PartidaController>();
             //var jogadaService = serviceProvider.GetService<JogadaService>();
            //var imensagemService = serviceProvider.GetService<IMensagemService>();
            //var mensagemService = serviceProvider.GetService<IMensagemService>();

            ipartidaService.IniciarPartida();
        }
    }
}
