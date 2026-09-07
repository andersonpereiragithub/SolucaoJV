using System;
using SolucaoJV.Application.Interfaces;

namespace SolucaoJV.UI.Views
{
    public class MensagemService : IMensagemService
    {
        string resposta = "";

        public void ExibirVencedor(string vencedor)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = vencedor == "X" ? ConsoleColor.Red : ConsoleColor.DarkGreen;
            
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
        }
        public void ExibirPosicaoOcupada(string posicao)
        {
            Console.SetCursorPosition(17, 16);
            Console.Write($"[{posicao}] já ocupada!");
        }
        public void LimparMensagemJogada()
        {
            int colunaAtual = Console.CursorLeft;
            int linhaAtual = Console.CursorTop;

            ConsoleColor corFundoAtual = Console.BackgroundColor;
            ConsoleColor corTextoAtual = Console.ForegroundColor;

            Console.SetCursorPosition(13, 16);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write(new string(' ', 30));

            Console.BackgroundColor = corFundoAtual;
            Console.ForegroundColor = corTextoAtual;

            Console.SetCursorPosition(colunaAtual, linhaAtual);
        }
    }
}
