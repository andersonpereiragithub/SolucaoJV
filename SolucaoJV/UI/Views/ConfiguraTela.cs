using SolucaoJV.Application.Interfaces;
using System;

namespace SolucaoJV.UI.Views
{
    class ConfiguraTela : IConfiguraTela
    {
        private const string tituloTela = "Jogo da Velha";
        public void ConfigurarTela()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(LayoutConsole.LarguraTela, LayoutConsole.AlturaTela);
                Console.SetBufferSize(LayoutConsole.LarguraTela, LayoutConsole.AlturaTela);
            }
            Console.Title = tituloTela;
        }
    }
}
