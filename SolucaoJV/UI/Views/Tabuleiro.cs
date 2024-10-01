using SolucaoJV;
using SolucaoJV.Application.Services;
using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.Services;
using System;
using PartidaDomainService = SolucaoJV.Domain.Services.PartidaDomainService;

namespace SolucaoJV.UI.Views
{
    class Tabuleiro
    {
        public static int origLinha = 0;
        public static int origColuna = 0;

        public void ImprimirTelaJogo()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
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

            int colunaInicial_X = 10;
            int linhaInicial_y = 3;
            int espacoEntreColunas = 7;
            int espacoEntreLinhas = 4;

            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    int posicaoX = colunaInicial_X + espacoEntreColunas * coluna;
                    int posicaoY = linhaInicial_y + espacoEntreLinhas * linha;

                    EscreverEm(posicoes[linha, coluna], posicaoX, posicaoY);

                }
            }
        }
        public void ImprimirControladores(PartidaDomainService p)
        {
            EscreverEm(Convert.ToString(p.Turno), 8, 13);
            EscreverEm(Convert.ToString(p.JogadorAtual), 10, 14);
            Console.SetCursorPosition(17, 15);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("  ");
            Console.SetCursorPosition(17, 15);
        }

        public void ImprimeJogadas(string jogador, int linha, int coluna)
        {
            if (linha == 0)
            {
                if (coluna == 0)
                    EscreverEm(jogador, 10, 3);
                else if (coluna == 1)
                    EscreverEm(jogador, 17, 3);
                else
                    EscreverEm(jogador, 24, 3);
            }
            else if (linha == 1)
            {
                if (coluna == 0)
                    EscreverEm(jogador, 10, 7);
                else if (coluna == 1)
                    EscreverEm(jogador, 17, 7);
                else
                    EscreverEm(jogador, 24, 7);
            }
            else
            {
                if (coluna == 0)
                    EscreverEm(jogador, 10, 11);
                else if (coluna == 1)
                    EscreverEm(jogador, 17, 11);
                else
                    EscreverEm(jogador, 24, 11);
            }
        }
        public void EscreverEm(string s, int linha, int coluna)
        {
            if (s == "X" || s == "O")
                AlterarCor(s, linha, coluna);
            else if (s == "1" || s == "2" || s == "3" || s == "4")
            {
                AlterarCor(s, linha, coluna);
            }
            else
            {
                Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
                Console.Write(s);
            }
        }

        private static void AlterarCor(string s, int linha, int coluna)
        {
            Console.BackgroundColor = ConsoleColor.White;

            if (s == Convert.ToString(TipoJogador.X) || s == Convert.ToString(TipoJogador.O))
            {
                Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
                Console.ForegroundColor = s == Convert.ToString(TipoJogador.X) ? ConsoleColor.Red : ConsoleColor.DarkGreen;
            }
            else
            {
                Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }

            Console.Write(s + " ");
            Console.ResetColor();
        }
        public void LimparTabuleiro()
        {
            Console.Clear();
        }
    }
}
