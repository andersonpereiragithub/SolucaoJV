using SolucaoJV.Application.Interfaces;
using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.Services;
using System;

namespace SolucaoJV.UI.Views
{
    class Tabuleiro : ITabuleiro
    {
        public static int origLinha = 0;
        public static int origColuna = 0;

        public Tabuleiro() { }

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
            if (linha == 0)
            {
                if (coluna == 0)
                    EscreverEm(jogador.ToString(), 10, 3);
                else if (coluna == 1)
                    EscreverEm(jogador.ToString(), 17, 3);
                else
                    EscreverEm(jogador.ToString(), 24, 3);
            }
            else if (linha == 1)
            {
                if (coluna == 0)
                    EscreverEm(jogador.ToString(), 10, 7);
                else if (coluna == 1)
                    EscreverEm(jogador.ToString(), 17, 7);
                else
                    EscreverEm(jogador.ToString(), 24, 7);
            }
            else
            {
                if (coluna == 0)
                    EscreverEm(jogador.ToString(), 10, 11);
                else if (coluna == 1)
                    EscreverEm(jogador.ToString(), 17, 11);
                else
                    EscreverEm(jogador.ToString(), 24, 11);
            }
        }

        public void EscreverEm(string letraNumeroOuTexto, int linha, int coluna)
        {
            bool seEhLetraOuNumero = letraNumeroOuTexto == "X" || letraNumeroOuTexto == "O" || letraNumeroOuTexto == "1" ||
                                     letraNumeroOuTexto == "2" || letraNumeroOuTexto == "3" || letraNumeroOuTexto == "4" ||
                                     letraNumeroOuTexto == "5";

            if (seEhLetraOuNumero)
            {
                AlterarCor(letraNumeroOuTexto, linha, coluna);
            }
            else
            {
                Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
                Console.Write(letraNumeroOuTexto);
            }
        }

        private static void AlterarCor(string jogadorChegou, int linha, int coluna)
        {
            string EhJogadorX = Convert.ToString(TipoJogador.X);
            string EhJogadorO = Convert.ToString(TipoJogador.O);

            Console.BackgroundColor = ConsoleColor.White;

            if (jogadorChegou == EhJogadorX || jogadorChegou == EhJogadorO)
            {
                Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
                Console.ForegroundColor = jogadorChegou == EhJogadorX ? ConsoleColor.Red : ConsoleColor.DarkGreen;
            }
            else
            {
                Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }

            Console.Write(jogadorChegou + " ");
            Console.ResetColor();
        }

        public void LimparTabuleiro()
        {
            Console.Clear();
        }
    }
}
