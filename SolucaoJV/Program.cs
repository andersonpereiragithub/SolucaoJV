using System;
using SolucaoJV.Application.Services;
using SolucaoJV.UI.Views;

namespace SolucaoJV.V
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ConfiguraTela tela = new ConfiguraTela();
            tela.ViewTela(
                bgColor: ConsoleColor.White,
                fgColor: ConsoleColor.Blue,
                largura: 40,
                altura: 18,
                titulo: "Jogo da Velha"
            );

            Tabuleiro tabuleiroUI = new Tabuleiro();
            PartidaService partidaService = new PartidaService(tabuleiroUI);

            partidaService.InciarPartida();

            while (!partidaService.JogoTerminou())
            {
                partidaService.RealizarJogada();
            }
        }
    }
}
