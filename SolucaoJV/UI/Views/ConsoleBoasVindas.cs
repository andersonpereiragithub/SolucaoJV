using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SolucaoJV.UI.Views
{
    internal class ConsoleBoasVindas
    {
        public static void Exibir()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            string mensagemBoasVindas = "Boas Vindas ao Jogo da Velha!";

            Console.WriteLine("\n\n\n\n    *********************************");
            Console.WriteLine("  **                                 **\n **                                   **\n  **                                 **");
            Console.WriteLine("    *********************************");
            Console.SetCursorPosition(6, 6);
            EscreverComEfeito(mensagemBoasVindas);            

            Console.WriteLine("\n\n\n\n                      By [Tio Delon]");
            Console.WriteLine("\n\nPressione qualquer tecla para começar...");
            Console.ReadKey();
        }

        private static void EscreverComEfeito(string mensagemBoasVindas, int espera = 50)
        {
            foreach(char caractere in mensagemBoasVindas)
            {
                
                Console.Write(caractere);
                Console.Beep(800, 30);
                Thread.Sleep(espera);
            }
        }
    }
}
