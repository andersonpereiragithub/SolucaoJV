using System;

namespace View
{
    class ConfiguraTela
    {
        public void ViewTela()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WindowWidth = 40;
            Console.WindowHeight = 18;
            Console.Title = "Jogo da Velha";

            Tabuleiro tab = new Tabuleiro();
            tab.ImprimirTelaJogo();
        }
    }
}
