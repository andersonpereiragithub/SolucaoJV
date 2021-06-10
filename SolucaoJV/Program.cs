using System;

namespace SolucaoJV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WindowWidth = 40;
            Console.WindowHeight = 18;
            Console.Title = "Jogo da Velha";

            Tela.ViewTela();
        }
    }
}
