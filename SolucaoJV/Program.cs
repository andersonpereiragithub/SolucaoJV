using System;
using SolucaoJV.Application.Services;
using SolucaoJV.Domain.Services;
using SolucaoJV.UI.Views;
using SolucaoJV.UI.Controllers;

namespace SolucaoJV.V
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro();
            ConfiguraTela configura = new ConfiguraTela();
            
            configura.ViewTela();

            PartidaDomainService partidaDomainService = new PartidaDomainService();

            PartidaAppService partidaAppService = new PartidaAppService(tabuleiro, partidaDomainService);
            
            partidaAppService.IniciarPartida();
        }
    }
}
