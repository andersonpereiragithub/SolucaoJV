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
            EscreverEm("### J O G O  D A  V E L H A ###", 4, 0, ConsoleColor.DarkBlue);

            DesenharLinhaVertical(14);
            DesenharLinhaVertical(21);

            DesenharLinhaHorizontal(5);
            DesenharLinhaHorizontal(9);

            DesenharPosicoesDeJogadas();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            EscreverEm("Turno: \nJogador [   ]", 0, 13, ConsoleColor.DarkBlue);
            EscreverEm("Sua vez: ", 8, 15, ConsoleColor.DarkBlue);
        }

        private void DesenharLinhaVertical(int posicaoX)
        {
            for (int posicaoY = 2; posicaoY < 13; posicaoY++)
            {
                EscreverEm("|", posicaoX, posicaoY, ConsoleColor.DarkBlue);
            }
        }

        private void DesenharLinhaHorizontal(int posicaoY)
        {
            for (int posicaoX = 8; posicaoX < 28; posicaoX++)
            {
                if (posicaoX == 14 || posicaoX == 21)
                {
                    EscreverEm("+", posicaoX, posicaoY, ConsoleColor.DarkBlue);
                }
                else
                {
                    EscreverEm("-", posicaoX, posicaoY, ConsoleColor.DarkBlue);
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

            for (int linha = 0; linha < posicoes.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < posicoes.GetLength(1); coluna++)
                {
                    (int posicaoX, int posicaoY) = CalcularPosicao(linha, coluna);

                    EscreverEm(posicoes[linha, coluna], posicaoX, posicaoY, ConsoleColor.DarkGray);
                }
            }
        }

        private (int posicaoX, int posicaoY) CalcularPosicao(int linha, int coluna)
        {
            int posicaoX = PosicaoInicialX + (EspacoEntreColunas * coluna);
            int posicaoY = PosicaoInicialY + (EspacoEntreLinhas * linha);

            return (posicaoX, posicaoY);
        }

        public void ImprimirControladores(int turno, TipoJogador jogadorAtual)
        {
            EscreverEm(Convert.ToString(turno), 8, 13);
            EscreverEm(Convert.ToString(jogadorAtual), 10, 14);
            Console.SetCursorPosition(LayoutConsole.PosicaoEntradaX, LayoutConsole.PosicaoEntradaY);

            Console.Write(new string(' ', LayoutConsole.QuantidadeCaracteresApagar));

            Console.SetCursorPosition(LayoutConsole.PosicaoEntradaX, LayoutConsole.PosicaoEntradaY);
        }

        public void ImprimeJogada(TipoJogador jogador, int linha, int coluna)
        {
            (int posicaoX, int posicaoY) = CalcularPosicao(linha, coluna);

            EscreverEm(jogador.ToString(), posicaoX, posicaoY);
        }

        private void EscreverEm(string valorExibido, int posicaoX, int posicaoY, ConsoleColor? cor = null)
        {
            Console.SetCursorPosition(OrigemX + posicaoX, OrigemY + posicaoY);

            if (cor.HasValue)
            {
                Console.ForegroundColor = cor.Value;
            }
            else
            {
                AlterarCor(valorExibido);
            }

            Console.Write(valorExibido + " ");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        private void AlterarCor(string valorExibido)
        {
            bool ehJogadorX = valorExibido == TipoJogador.X.ToString();
            bool ehJogadorO = valorExibido == TipoJogador.O.ToString();
            bool ehTurno = int.TryParse(valorExibido, out int turno) && turno >= 1 && turno <= 5;

            Console.BackgroundColor = ConsoleColor.White;

            if (ehJogadorX || ehJogadorO)
            {
                Console.ForegroundColor = ehJogadorX ? ConsoleColor.Red : ConsoleColor.DarkGreen;
            }
            else if (ehTurno)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
    }
}
