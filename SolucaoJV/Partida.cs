using System;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV
{
    class Partida
    {
        public static int origLinha;
        public static int origColuna;
        public Tela tab { get; set; }
        public int QtePartida { get; set; }
        public int Turno { get; set; }
        public Tipo jogadorAtual { get; private set; }
        public bool Terminada { get; set; }

        public Partida()
        {
            QtePartida = 0;
            Turno = 1;
            jogadorAtual = Tipo.X;
            Terminada = false;
        }

        public void IncrementaTurno()
        {
            Turno++;
        }
        public void MudarJogador()
        {
            if (jogadorAtual == Tipo.X)
                jogadorAtual = Tipo.O;
            else
            {
                IncrementaTurno();
                jogadorAtual = Tipo.X;
            }
        }
        //public void PreencherTela(string[,] tab)
        //{
        //    for (int i = 0; i < tab.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < tab.GetLength(1); j++)
        //        {
        //            if (i == 0)
        //                tab[i, j] = "a" + (j + 1);
        //            else if (i == 1)
        //                tab[i, j] = "b" + (j + 1);
        //            else
        //                tab[i, j] = "c" + (j + 1);
        //        }
        //        Console.WriteLine();
        //    }
        //}
        public void PreencherJogada(string[,] tab)
        {
            origLinha = 0;
            origColuna = 0;

            Console.Clear();
            EscreverEm("### J O G O  D A  V E L H A ###", 4, 0);

            //Colunas
            EscreverEm("|", 14, 2);
            EscreverEm("|", 14, 3);

            if (tab[0, 0] == "X" || tab[0, 0] == "O")
                EscreverEm(tab[0, 0], 10, 3);
            else
                EscreverEm("a1", 10, 3);

            EscreverEm("|", 14, 4);
            EscreverEm("+", 14, 5);

            //colunas
            EscreverEm("|", 21, 2);
            EscreverEm("|", 21, 3);

            if (tab[0, 1] == "X" || tab[0, 1] == "O")
                EscreverEm(tab[0, 1], 17, 3);
            else
                EscreverEm("a2", 17, 3);

            if (tab[0, 2] == "X" || tab[0, 2] == "O")
                EscreverEm(tab[0, 2], 24, 3);
            else
                EscreverEm("a3", 24, 3);

            EscreverEm("|", 21, 4);
            EscreverEm("+", 21, 5);

            //linhas
            EscreverEm("-", 8, 5);
            EscreverEm("-", 9, 5);
            EscreverEm("-", 10, 5);
            EscreverEm("-", 11, 5);
            EscreverEm("-", 12, 5);
            EscreverEm("-", 13, 5);

            //Linhas
            EscreverEm("-", 15, 5);
            EscreverEm("-", 16, 5);
            EscreverEm("-", 17, 5);
            EscreverEm("-", 18, 5);
            EscreverEm("-", 19, 5);
            EscreverEm("-", 20, 5);

            //linhas
            EscreverEm("-", 22, 5);
            EscreverEm("-", 23, 5);
            EscreverEm("-", 24, 5);
            EscreverEm("-", 25, 5);
            EscreverEm("-", 26, 5);
            EscreverEm("-", 27, 5);
            //--------------------------------------

            //Colunas
            EscreverEm("|", 14, 6);

            if (tab[1, 0] == "X" || tab[1, 0] == "O")
                EscreverEm(tab[1, 0], 10, 7);
            else
                EscreverEm("b1", 10, 7);

            EscreverEm("|", 14, 7);
            EscreverEm("|", 14, 8);
            EscreverEm("+", 14, 9);

            //Colunas
            EscreverEm("|", 21, 6);
            EscreverEm("|", 21, 7);

            if (tab[1, 1] == "X" || tab[1, 1] == "O")
                EscreverEm(tab[1, 1], 17, 7);
            else
                EscreverEm("b2", 17, 7);

            if (tab[1, 2] == "X" || tab[1, 2] == "O")
                EscreverEm(tab[1, 2], 24, 7);
            else
                EscreverEm("b3", 24, 7);

            EscreverEm("|", 21, 8);
            EscreverEm("+", 21, 9);

            //linhas
            EscreverEm("-", 8, 9);
            EscreverEm("-", 9, 9);
            EscreverEm("-", 10, 9);
            EscreverEm("-", 11, 9);
            EscreverEm("-", 12, 9);
            EscreverEm("-", 13, 9);

            //linhas
            EscreverEm("-", 15, 9);
            EscreverEm("-", 16, 9);
            EscreverEm("-", 17, 9);
            EscreverEm("-", 18, 9);
            EscreverEm("-", 19, 9);
            EscreverEm("-", 20, 9);

            //Linhas
            EscreverEm("-?", 22, 9);
            EscreverEm("-", 23, 9);
            EscreverEm("-", 24, 9);
            EscreverEm("-", 25, 9);
            EscreverEm("-", 26, 9);
            EscreverEm("-", 27, 9);

            //===========================

            EscreverEm("|", 14, 10);
            EscreverEm("|", 14, 11);

            if (tab[2, 0] == "X" || tab[2, 0] == "O")
                EscreverEm(tab[2, 0], 10, 11);
            else
                EscreverEm("c1", 10, 11);

            EscreverEm("|", 14, 12);
            EscreverEm("|", 21, 10);
            EscreverEm("|", 21, 11);

            if (tab[2, 1] == "X" || tab[2, 1] == "O")
                EscreverEm(tab[2, 1], 17, 11);
            else
                EscreverEm("c2", 17, 11);

            if (tab[2, 2] == "X" || tab[2, 2] == "0")
                EscreverEm(tab[2, 2], 24, 11);
            else
                EscreverEm("c3", 24, 11);

            EscreverEm("|", 21, 12);

            Console.WriteLine();
        }
        public static void EscreverEm(string s, int linha, int coluna)
        {
            Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
            Console.Write(s);
        }
    }
}
