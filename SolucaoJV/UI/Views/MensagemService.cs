using System;
using SolucaoJV.Application.Interfaces;

namespace SolucaoJV.UI.Views
{
    public class MensagemService : IMensagemService
    {
        string resposta = "";

        public void ExibirVencedor(string vencedor)
        {
            Console.SetCursorPosition(14, 14);
            Console.WriteLine($"{vencedor} VENCEU!!!");
        }
        public void ExibirEmpate()
        {
            Console.SetCursorPosition(14, 14);
            Console.WriteLine($"Houve EMPATE!!!");
        }
        public void MensagemSeDesejaReiniciar()
        {
            Console.SetCursorPosition(3, 15);
            Console.WriteLine("Deseja reiniciar o jogo? (s/n): ");
            Console.SetCursorPosition(34, 15);

            //resposta = Console.ReadLine().ToLower();

            //if (resposta[0] == 's')
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}
