using System;

namespace SolucaoJV.UI.Views
{
    class ConfiguraTela
    {
        public void ViewTela(ConsoleColor bgColor, ConsoleColor fgColor, int largura, int altura, string titulo)
        {
            Console.SetWindowSize(largura, altura);
            Console.SetBufferSize(largura, altura);
            Console.Title = titulo;
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;

            Tabuleiro tab = new Tabuleiro();
            tab.ImprimirTelaJogo();
        }
    }
}
