using SolucaoJV.Application.Interfaces;
using System;
using System.Threading;

namespace SolucaoJV.UI.Views
{
    internal class ConsoleBoasVindas : IBoasVindas
    {
        private const string mensagem = "Seja bem-vindo ao Jogo da Velha!";
        private const int IntervaloEfeitoMs = 50;

        private const int MolduraTopoX = 4;
        private const int MolduraTopoY = 4;

        private const int MensagemX = 5;
        private const int MensagemY = 6;

        private const int AssinaturaX = 22;
        private const int AssinaturaY = 10;

        private const int InstrucaoX = 0;
        private const int InstrucaoY = 13;
        public void Exibir()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(MolduraTopoX, MolduraTopoY);
            Console.WriteLine("*********************************");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("**                                 **");
            Console.SetCursorPosition(1, 6);
            Console.WriteLine("**                                   **");
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("**                                 **");
            Console.SetCursorPosition(4, 8);
            Console.WriteLine("*********************************");
            Console.SetCursorPosition(MensagemX, MensagemY);
            EscreverComEfeito(mensagem);

            Console.SetCursorPosition(AssinaturaX, AssinaturaY);
            Console.WriteLine("By [Tio Delon]");
            Console.SetCursorPosition(InstrucaoX, InstrucaoY);
            Console.WriteLine("Pressione qualquer tecla para começar...");
            Console.ReadKey(true);
        }

        private void EscreverComEfeito(string mensagem)
        {
            foreach (char caractere in mensagem)
            {
                Console.Write(caractere);
                Thread.Sleep(IntervaloEfeitoMs);
            }
        }
    }
}
