﻿using Microsoft.Extensions.DependencyInjection;
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
             IniciarJogo(); 
        }
        
        public static void IniciarJogo()
        {
            bool jogarNovamente = true;

            while (jogarNovamente)
            {

                var serviceProvider = new ServiceCollection()
                    .AddSingleton<Tabuleiro>()
                    .AddSingleton<ConfiguraTela>()
                    .AddSingleton<PartidaDomainService>()
                    .AddSingleton<PartidaController>()
                    .AddSingleton<Posicao>()
                    .AddSingleton<IPartidaService, PartidaAppService>()
                    .AddSingleton<IMensagemService, MensagemService>()
                    .BuildServiceProvider();

                var tabuleiro = serviceProvider.GetServices<Tabuleiro>();
                var configuraTela = serviceProvider.GetService<ConfiguraTela>();
                var posicao = serviceProvider.GetService<Posicao>();
                var partidaAppService = serviceProvider.GetService<PartidaAppService>();
                var ipartidaService = serviceProvider.GetService<IPartidaService>();
                var partidaController = serviceProvider.GetRequiredService<PartidaController>();
                var imensagemService = serviceProvider.GetService<IMensagemService>();
                var mensagemService = serviceProvider.GetService<IMensagemService>();

                configuraTela.ViewTela();

                ipartidaService.IniciarPartida();
                
                if(imensagemService.PerguntarSeDesejaReiniciar() == 's'.ToString())
                {
                    jogarNovamente = true;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
