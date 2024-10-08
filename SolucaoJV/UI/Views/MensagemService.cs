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
            Console.WriteLine("Deseja reiniciar o jogo? (s/n)");
            return Console.ReadLine();
        }
    }
}
