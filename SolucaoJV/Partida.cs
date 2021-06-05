using System;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV
{
    class Partida
    {
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
        public void PreencherTela(string[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (i == 0)
                        tab[i, j] = "a" + (j + 1);
                    else if (i == 1)
                        tab[i, j] = "b" + (j + 1);
                    else
                        tab[i, j] = "c" + (j + 1);
                }
                Console.WriteLine();
            }
        }
        public void PreencherJogada(string[,] tab)
        {
            Console.Clear();
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (i == 0)
                        Console.Write("[{0}]", tab[i, j]);
                    else if (i == 1)
                        Console.Write("[{0}]", tab[i, j]);
                    else
                        Console.Write("[{0}]", tab[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
