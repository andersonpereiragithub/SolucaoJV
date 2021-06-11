using System;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV
{
    class Tela
    {
        public static int origLinha = 0;
        public static int origColuna = 0;

        public static void ViewTela()
        {
            ImprimirTelaJogo();

            Partida.IniciarPartida();
        }
        public static void SetJogadas(string jogador, int linha, int coluna)
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
        public static void EscreverEm(string s, int linha, int coluna)
        {
            if (s == "X" || s == "O")
                AlterarCor(s, linha, coluna);
            else
            {
                Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
                Console.Write(s);
            }
        }

        private static void AlterarCor(string s, int linha, int coluna)
        {
            if (s == Convert.ToString(TipoJogador.X))
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(s + " ");
                Console.ResetColor();
            }
            if (s == Convert.ToString(TipoJogador.O))
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(s + " ");
                Console.ResetColor();
            }
        }
        public static void ImprimirTelaJogo()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            EscreverEm("### J O G O  D A  V E L H A ###", 4, 0);
            
            for (int i = 2; i < 13; i++)
            {
                EscreverEm("|", 14, i);
                EscreverEm("|", 21, i);
            }
            for (int i = 8; i < 28; i++)
            {
                EscreverEm("-", i, 5);
                EscreverEm("-", i, 9);
            }

            EscreverEm("+", 14, 5);
            EscreverEm("+", 14, 9);
            EscreverEm("+", 21, 5);
            EscreverEm("+", 21, 9);

            EscreverEm("a1", 10, 3);
            EscreverEm("a2", 17, 3);
            EscreverEm("a3", 24, 3);
            EscreverEm("b1", 10, 7);
            EscreverEm("b2", 17, 7);
            EscreverEm("b3", 24, 7);
            EscreverEm("c1", 10, 11);
            EscreverEm("c2", 17, 11);
            EscreverEm("c3", 24, 11);

            Console.ResetColor();
        }
    }
}
