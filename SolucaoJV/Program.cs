using System;
using View;

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
        }
    }
}
