using SolucaoJV.Application.Interfaces;
using SolucaoJV.Domain.Entities;
using System;
using System.Threading;

namespace SolucaoJV.UI.Views
{
    public class MensagemService : IMensagemService
    {
        private const int TempoMensagemInvalida = 3;
        private const int IntervaloMensagemInvalida = 1000;

        public void ExibirVencedor(TipoJogador vencedor)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = vencedor == TipoJogador.X ? ConsoleColor.Red : ConsoleColor.DarkGreen;

            Console.SetCursorPosition(LayoutConsole.PosicaoResultadoX, LayoutConsole.PosicaoResultadoY);
            Console.WriteLine($"---> VENCEU!!!");
        }
        public void ExibirEmpate()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(LayoutConsole.PosicaoResultadoX, LayoutConsole.PosicaoResultadoY);
            Console.WriteLine($"Houve EMPATE!!!");
        }
        public void ExibirMensagemReinicio()
        {
            Console.SetCursorPosition(LayoutConsole.PosicaoMensagemReinicioX, LayoutConsole.PosicaoMensagemReinicioY);
            Console.WriteLine("Deseja reiniciar o jogo? (s/n): ");
            Console.SetCursorPosition(LayoutConsole.PosicaoRespostaReinicioX, LayoutConsole.PosicaoMensagemReinicioY);
        }
        public void ExibirPosicaoOcupada(int linha, int coluna)
        {
            string posicao = $"{(char)('a' + linha)}{coluna + 1}";
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.SetCursorPosition(LayoutConsole.PosicaoMensagemJogadaX, LayoutConsole.PosicaoMensagemJogadaY);
            Console.Write($"[{posicao}] já ocupada!");
        }
        public void LimparMensagemJogada()
        {
            int posicaoAtualX = Console.CursorLeft;
            int posicaoAtualY = Console.CursorTop;

            ConsoleColor corFundoAtual = Console.BackgroundColor;
            ConsoleColor corTextoAtual = Console.ForegroundColor;

            Console.SetCursorPosition(17, 16);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write(new string(' ', LayoutConsole.QuantidadeCaracteresApagar));

            Console.BackgroundColor = corFundoAtual;
            Console.ForegroundColor = corTextoAtual;

            Console.SetCursorPosition(posicaoAtualX, posicaoAtualY);
        }
        public void ExibirJogadaInvalida()
        {
            int tempo = TempoMensagemInvalida;

            for (int i = 0; i < TempoMensagemInvalida; i++)
            {
                Console.SetCursorPosition(LayoutConsole.PosicaoEntradaX, LayoutConsole.PosicaoEntradaY);
                Console.WriteLine($"Jogada Inválida...({tempo})");
                Thread.Sleep(IntervaloMensagemInvalida);
                tempo--;
            }
            Console.SetCursorPosition(LayoutConsole.PosicaoEntradaX, LayoutConsole.PosicaoEntradaY);

            Console.Write(new string(' ', LayoutConsole.QuantidadeCaracteresApagar));

            Console.SetCursorPosition(LayoutConsole.PosicaoEntradaX, LayoutConsole.PosicaoEntradaY);
        }
    }
}
