using SolucaoJV.Application.Interfaces;
using System;
using System.Threading;

namespace SolucaoJV.UI.Views
{
    internal class ConsoleBoasVindas : IBoasVindas
    {
        public void Exibir()
        {
            string mensagem = "Seja bem-vindo ao Jogo da Velha!";

            Console.WriteLine("\n\n\n\n    *********************************");
            Console.WriteLine("  **                                 **\n **                                   **\n  **                                 **");
            Console.WriteLine("    *********************************");
            Console.SetCursorPosition(5, 6);
            EscreverComEfeito(mensagem);            

            Console.WriteLine("\n\n\n\n                      By [Tio Delon]");
            Console.WriteLine("\n\nPressione qualquer tecla para começar...");
            Console.ReadKey();
        }

        private void EscreverComEfeito(string mensagem, int espera = 50)
        {
            foreach(char caractere in mensagem)
            {
                Console.Write(caractere);
                Thread.Sleep(espera);
            }
        }
    }
}
