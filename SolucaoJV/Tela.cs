using System;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV
{
    class Tela
    {
        public static int origLinha;
        public static int origColuna;

        public static void ViewTela()
        {
            Partida partida = new Partida();
                                   
            ImprimirTelaJogo(partida.Jogadas);

            while (!partida.Terminada)
            {
                bool posicao = false;
                Posicao p = new Posicao();
                EscreverEm("Turno: ", 0, 13); 
                EscreverEm(Convert.ToString(partida.Turno), 8, 13);
                EscreverEm("Jogador [", 0, 14);
                EscreverEm(Convert.ToString(partida.jogadorAtual), 9, 14);
                EscreverEm("]", 10, 14);
                p.InserirJogada();
                
                while (!posicao)
                {
                    if (partida.Jogadas[p.Linha, p.Coluna] == null)
                    {
                        partida.Jogadas[p.Linha, p.Coluna] = Convert.ToString(partida.jogadorAtual);
                                                
                        posicao = true;
                    }
                    else
                    {
                        p.JogadaInvalida();
                        p.InserirJogada();
                    }
                }


                ImprimirTelaJogo(partida.Jogadas);
                
                partida.MudarJogador();

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
                Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(s);
                Console.ResetColor();
            }
            if (s == Convert.ToString(TipoJogador.O))
            {
                Console.SetCursorPosition(origLinha + linha, origColuna + coluna);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(s);
                Console.ResetColor();
            }
        }
        public static void ImprimirTelaJogo(string[,] tab)
        {
            origLinha = 0;
            origColuna = 0;

            Console.Clear();
            EscreverEm("### J O G O  D A  V E L H A ###", 4, 0);

            //Colunas
            EscreverEm("|", 14, 2);
            EscreverEm("|", 14, 3);
            EscreverEm("|", 14, 4);
            EscreverEm("+", 14, 5);
            EscreverEm("|", 21, 2);
            EscreverEm("|", 21, 3);
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
            
            //Colunas
            EscreverEm("|", 14, 6);

            //linhas
            EscreverEm("-", 8, 9);
            EscreverEm("-", 9, 9);
            EscreverEm("-", 10, 9);
            EscreverEm("-", 11, 9);
            EscreverEm("-", 12, 9);
            EscreverEm("-", 13, 9);

            EscreverEm("|", 14, 7);
            EscreverEm("|", 14, 8);
            EscreverEm("+", 14, 9);

            EscreverEm("-", 15, 9);
            EscreverEm("-", 16, 9);
            EscreverEm("-", 17, 9);
            EscreverEm("-", 18, 9);
            EscreverEm("-", 19, 9);
            EscreverEm("-", 20, 9);

            EscreverEm("|", 21, 6);
            EscreverEm("|", 21, 7);
            EscreverEm("|", 21, 8);
            EscreverEm("+", 21, 9);

            //Linhas
            EscreverEm("-", 22, 9);
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

            if (tab[2, 2] == "X" || tab[2, 2] == "O")
                EscreverEm(tab[2, 2], 24, 11);
            else
                EscreverEm("c3", 24, 11);

            EscreverEm("|", 21, 12);

            if (tab[0, 0] == "X" || tab[0, 0] == "O")
                EscreverEm(tab[0, 0], 10, 3);
            else
                EscreverEm("a1", 10, 3);

            if (tab[0, 1] == "X" || tab[0, 1] == "O")
                EscreverEm(tab[0, 1], 17, 3);
            else
                EscreverEm("a2", 17, 3);

            if (tab[0, 2] == "X" || tab[0, 2] == "O")
                EscreverEm(tab[0, 2], 24, 3);
            else
                EscreverEm("a3", 24, 3);

            if (tab[1, 0] == "X" || tab[1, 0] == "O")
                EscreverEm(tab[1, 0], 10, 7);
            else
                EscreverEm("b1", 10, 7);

            if (tab[1, 1] == "X" || tab[1, 1] == "O")
                EscreverEm(tab[1, 1], 17, 7);
            else
                EscreverEm("b2", 17, 7);

            if (tab[1, 2] == "X" || tab[1, 2] == "O")
                EscreverEm(tab[1, 2], 24, 7);
            else
                EscreverEm("b3", 24, 7);


            Console.WriteLine();
        }
    }
}
