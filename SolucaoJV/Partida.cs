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
        public TipoJogador jogadorAtual { get; private set; }
        public bool Terminada { get; set; }
        public string[,] Jogadas { get; set; }

        public Partida()
        {
            QtePartida = 0;
            Turno = 1;
            jogadorAtual = TipoJogador.X;
            Terminada = false;
            Jogadas = new string[3, 3];
        }

        public void IncrementarTurno()
        {
            Turno++;
        }
        public void MudarJogador()
        {
            if (jogadorAtual == TipoJogador.X)
                jogadorAtual = TipoJogador.O;
            else
            {
                IncrementarTurno();
                jogadorAtual = TipoJogador.X;
            }
        }

        public void VefificarVitoria()
        {
            int v = CondicaoDeVitoria(Jogadas);
            if (v == 1)
            {
                Tela.EscreverEm(Convert.ToString(jogadorAtual), 20, 15);
                if (Convert.ToString(jogadorAtual) == "X")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Tela.EscreverEm("Venceu!!!", 12, 14);
                    ReiniciarPartida();
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Tela.EscreverEm("Venceu!!!", 12, 14);
                    ReiniciarPartida();
                    Console.ResetColor();
                }
            }
            else if (v == -1)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Tela.EscreverEm("Deu EMPATE!", 17, 15);
                ReiniciarPartida();
                Console.ResetColor();
            }
        }
        public int CondicaoDeVitoria(string[,] mat)
        {
            if (mat[0, 0] == "X" && mat[0, 1] == "X" && mat[0, 2] == "X" ||
               mat[1, 0] == "X" && mat[1, 1] == "X" && mat[1, 2] == "X" ||
               mat[2, 0] == "X" && mat[2, 1] == "X" && mat[2, 2] == "X" ||
               mat[0, 0] == "X" && mat[1, 1] == "X" && mat[2, 2] == "X" ||
               mat[0, 2] == "X" && mat[1, 1] == "X" && mat[2, 0] == "X" ||
               mat[0, 0] == "X" && mat[1, 0] == "X" && mat[2, 0] == "X" ||
               mat[0, 1] == "X" && mat[1, 1] == "X" && mat[2, 1] == "X" ||
               mat[0, 2] == "X" && mat[1, 2] == "X" && mat[2, 2] == "X" ||

               mat[0, 0] == "O" && mat[0, 1] == "O" && mat[0, 2] == "O" ||
               mat[1, 0] == "O" && mat[1, 1] == "O" && mat[1, 2] == "O" ||
               mat[2, 0] == "O" && mat[2, 1] == "O" && mat[2, 2] == "O" ||
               mat[0, 0] == "O" && mat[1, 1] == "O" && mat[2, 2] == "O" ||
               mat[0, 2] == "O" && mat[1, 1] == "O" && mat[2, 0] == "O" ||
               mat[0, 0] == "O" && mat[1, 0] == "O" && mat[2, 0] == "O" ||
               mat[0, 1] == "O" && mat[1, 1] == "O" && mat[2, 1] == "O" ||
               mat[0, 2] == "O" && mat[1, 2] == "O" && mat[2, 2] == "O")
            {
                Terminada = true;
                return 1;
            }

            else if (mat[0, 0] != null && mat[1, 0] != null && mat[2, 0] != null &&
                     mat[0, 1] != null && mat[1, 1] != null && mat[2, 1] != null &&
                     mat[0, 2] != null && mat[1, 2] != null && mat[2, 2] != null)
                return -1;
            else
                return 0;
        }
        public void ReiniciarPartida()
        {
            Tela.EscreverEm("Deseja Reinciar (s/n)? ", 10 , 16);
            char resp = char.Parse(Console.ReadLine());
            if (resp.Equals('s'))
                Tela.ViewTela();

            Environment.Exit(0);
        }
    }
}
