using System;

namespace SolucaoJV.UI.Views
{
    class ConfiguraTela
    {
        private readonly Tabuleiro _tabuleiro;

        public ConfiguraTela(Tabuleiro tabuleiro)
        {
            _tabuleiro = tabuleiro;
        }

        public void ViewTela()
        {
            int larguraTela = 40;
            int alturaTela = 18;
            string tituloTela = "Jogo da Velha";
            
            Console.SetWindowSize(larguraTela, alturaTela);
            Console.SetBufferSize(larguraTela, alturaTela);
            Console.Title = tituloTela;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;

            _tabuleiro.DesenharTabuleiroJogo();
        }
    }
}
