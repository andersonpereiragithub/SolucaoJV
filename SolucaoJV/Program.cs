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
            ConfiguraTela tela = new ConfiguraTela();
            tela.ViewTela();

            var partidaDomainService = new PartidaDomainService();
            var partidaAppService = new PartidaAppService(partidaDomainService);

            var partidaController = new PartidaController(partidaAppService);

            partidaController.IniciarPartida();
        }
    }
}
