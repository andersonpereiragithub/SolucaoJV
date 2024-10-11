using System;
using SolucaoJV.Application.Interfaces;

namespace SolucaoJV.UI.Views
{
    public class MensagemService : IMensagemService
    {
        string resposta = "";

        public void ExibirVencedor(string vencedor)
        {
            Console.WriteLine($"{vencedor} VENCEU!!!");
        }
        public bool PerguntarSeDesejaReiniciar()
        {
            Console.SetCursorPosition(3, 15);
            Console.WriteLine("Deseja reiniciar o jogo? (s/n): ");
            Console.SetCursorPosition(34, 15);

            resposta = Console.ReadLine().ToLower();

            if (resposta[0] == 's')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
