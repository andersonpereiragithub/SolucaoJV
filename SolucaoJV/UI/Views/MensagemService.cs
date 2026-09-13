using SolucaoJV.Application.Interfaces;
using SolucaoJV.Domain.Entities;
using System;
using System.Threading;

namespace SolucaoJV.UI.Views
{
    public class MensagemService : IMensagemService
    {
        public void ExibirVencedor(TipoJogador vencedor)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = vencedor == TipoJogador.X ? ConsoleColor.Red : ConsoleColor.DarkGreen;

            Console.SetCursorPosition(14, 14);
            Console.WriteLine($"---> VENCEU!!!");
        }
        public void ExibirEmpate()
        {
            Console.SetCursorPosition(14, 14);
            Console.WriteLine($"Houve EMPATE!!!");
        }
        public void ExibirMensagemReinicio()
        {
            Console.SetCursorPosition(3, 15);
            Console.WriteLine("Deseja reiniciar o jogo? (s/n): ");
            Console.SetCursorPosition(34, 15);
        }
        public void ExibirPosicaoOcupada(int linha, int coluna)
        {
            string posicao = $"{(char)('a' + linha)}{coluna + 1}";

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
        public void ExibirJogadaInvalida()
        {
            int tempo = 3;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(LayoutConsole.PosicaoEntradaX, LayoutConsole.PosicaoEntradaY);
                Console.WriteLine($"Jogada Inválida...({tempo})");
                Thread.Sleep(1000);
                tempo--;
            }
            Console.SetCursorPosition(LayoutConsole.PosicaoEntradaX, LayoutConsole.PosicaoEntradaY);

            Console.Write(new string(' ', LayoutConsole.QuantidadeCaracteresApagar));

            Console.SetCursorPosition(LayoutConsole.PosicaoEntradaX, LayoutConsole.PosicaoEntradaY);
        }
    }
}
