using SolucaoJV.Application.Interfaces;
using System;

namespace SolucaoJV.UI.Views
{
    class ConfiguraTela : IConfiguraTela
    {
        public void ViewTela()
        {
            int larguraTela = 40;
            int alturaTela = 18;

            string tituloTela = "Jogo da Velha";

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(larguraTela, alturaTela);
                Console.SetBufferSize(larguraTela, alturaTela);
            }
                Console.Title = tituloTela;
        }
    }
}
