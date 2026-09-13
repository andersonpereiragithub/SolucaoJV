using SolucaoJV.Application.Interfaces;
using SolucaoJV.Domain.Entities;
using System;

namespace SolucaoJV.UI.Views
{
    class Tabuleiro : ITabuleiro
    {
        private const int OrigemX = 0;
        private const int OrigemY = 0;

        private const int PosicaoInicialX = 10;
        private const int PosicaoInicialY = 3;
        private const int EspacoEntreColunas = 7;
        private const int EspacoEntreLinhas = 4;

        public void DesenharTabuleiroJogo()
        {
            Console.Clear();
            EscreverEm("### J O G O  D A  V E L H A ###", 4, 0);

            DesenharLinhaVertical(14);
            DesenharLinhaVertical(21);

            DesenharLinhaHorizontal(5);
            DesenharLinhaHorizontal(9);

            DesenharPosicoesDeJogadas();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            EscreverEm("Turno: \nJogador [   ]", 0, 13);
            Console.SetCursorPosition(8, 15);
            Console.Write("Sua vez: ");
        }

        private void DesenharLinhaVertical(int coluna)
        {
            for (int i = 2; i < 13; i++)
            {
                EscreverEm("|", coluna, i);
            }
        }

        private void DesenharLinhaHorizontal(int linha)
        {
            for (int i = 8; i < 28; i++)
            {
                if (i == 14 || i == 21)
                {
                    EscreverEm("+", i, linha);
                }
                else
                {
                    EscreverEm("-", i, linha);
                }
            }
        }

        private void DesenharPosicoesDeJogadas()
        {
            string[,] posicoes = {
                { "a1", "a2", "a3" },
                { "b1", "b2", "b3" },
                { "c1", "c2", "c3" }
            };

            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    int posicaoX = PosicaoInicialX + (EspacoEntreColunas * coluna);
                    int posicaoY = PosicaoInicialY + (EspacoEntreLinhas * linha);

                    EscreverEm(posicoes[linha, coluna], posicaoX, posicaoY);
                }
            }
        }

        public void ImprimirControladores(int turno, TipoJogador jogadorAtual)
        {
            EscreverEm(Convert.ToString(turno), 8, 13);
            EscreverEm(Convert.ToString(jogadorAtual), 10, 14);
            Console.SetCursorPosition(17, 15);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write(new string(' ', 25));

            Console.SetCursorPosition(17, 15);
        }

        public void ImprimeJogadas(TipoJogador jogador, int linha, int coluna)
        {
            int posicaoX = PosicaoInicialX + (EspacoEntreColunas * coluna);
            int posicaoY = PosicaoInicialY + (EspacoEntreLinhas * linha);

            EscreverEm(jogador.ToString(), posicaoX, posicaoY);
        }

        private void EscreverEm(string valorExibido, int posicaoX, int posicaoY)
        {
            bool ehTurno = int.TryParse(valorExibido, out int turno) && turno >= 1 && turno <= 5;

            bool deveAlterarCor = valorExibido == "X" || valorExibido == "O" || ehTurno;

            Console.SetCursorPosition(OrigemX + posicaoX, OrigemY + posicaoY);

            if (deveAlterarCor)
            {
                AlterarCor(valorExibido);
            }
            else
            {
                Console.Write(valorExibido);
            }
        }

        private void AlterarCor(string valorExibido)
        {
            bool ehJogadorX = valorExibido == TipoJogador.X.ToString();
            bool ehJogadorO = valorExibido == TipoJogador.O.ToString();

            Console.BackgroundColor = ConsoleColor.White;

            if (ehJogadorX || ehJogadorO)
            {
                Console.ForegroundColor = valorExibido == TipoJogador.X.ToString() ? ConsoleColor.Red : ConsoleColor.DarkGreen;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }

            Console.Write(valorExibido + " ");
            Console.ResetColor();
        }
    }
}
