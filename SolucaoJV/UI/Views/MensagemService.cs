using System;
using SolucaoJV.Application.Interfaces;

namespace SolucaoJV.UI.Views
{
    public class MensagemService : IMensagemService
    {
        public void ExibirVencedor(string vencedor)
        {
            Console.WriteLine($"{vencedor} VENCEU!!!");
        }

        public string PerguntarSeDesejaReiniciar()
        {
            Console.SetCursorPosition(7, 15);
            Console.WriteLine("Deseja reiniciar o jogo? (s/n)");
            return Console.ReadLine();
        }
    }
}
