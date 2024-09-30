using System;
using SolucaoJV.Application.Services;
using SolucaoJV.Domain.ValueObjects;
using SolucaoJV.UI;
using System.Threading;

namespace SolucaoJV.UI.Controllers
{
    internal class PartidaController
    {
        private readonly PartidaService _partidaService;
        private readonly ConsoleUI _CON
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public void RegistrarJogada(int linha, int coluna)
        {
            Linha = linha - 'a';
            Coluna = coluna - 1;
        }

        public void LerJogada()
        {
            try
            {
                string jogada = Console.ReadLine();

                if (JogadaValida(jogada))
                {
                    char linha = jogada[0];
                    int coluna = int.Parse(jogada[1] + "");
                    //RegistrarJogada(linha, coluna);
                }
                else
                {
                    JogadaInvalida();
                }
            }
            catch
            {
                JogadaInvalida();
            }
        }
        public void JogadaInvalida()
        {
            int t = 3;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < 3; i++)
            {
                PosicaoCursorMsg($"Jogada Inválida...({t})");
                Thread.Sleep(1000);
                t--;
            }

            LimpaMsg();
        }

        private void LimpaMsg()
        {
            PosicaoCursorMsg("                           ");
            PosicaoCursorMsg("");
        }

        private void PosicaoCursorMsg(string msg)
        {
            Console.SetCursorPosition(17, 15);
            Console.Write(msg);
            Thread.Sleep(1000);
        }
        public void MudarJogador(TipoJogador jogadorAtual)
        {
            if (jogadorAtual == TipoJogador.X)
                jogadorAtual = TipoJogador.O;
        }
    }
}
