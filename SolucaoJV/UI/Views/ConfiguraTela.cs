using System;

namespace SolucaoJV.UI.Views
{
    class ConfiguraTela
    {
        public void ViewTela()
        {
            int larguraTela = 40;
            int alturaTela = 18;

            string tituloTela = "Jogo da Velha";

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.SetWindowSize(larguraTela, alturaTela);
            Console.SetBufferSize(larguraTela, alturaTela);
            Console.Title = tituloTela;
        }
    }
}
