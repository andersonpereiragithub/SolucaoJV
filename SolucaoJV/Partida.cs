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
            Jogadas = new string[3,3];
        }
        public void MarcarTabuleiro(string[,] jogadas, TipoJogador jogador) 
        { 
            
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
            if (Turno >= 3)
            {
                CondicaoDeVitoria(Jogadas);
            }
        }
        public void CondicaoDeVitoria(string[,] mat)
        {
            if (mat[0, 0] == "X" && mat[0, 1] == "X" && mat[0, 2] == "X" ||
               mat[1, 0] == "X" && mat[1, 1] == "X" && mat[1, 2] == "X" ||
               mat[2, 0] == "X" && mat[2, 1] == "X" && mat[2, 2] == "X" ||
               mat[0, 0] == "X" && mat[1, 1] == "X" && mat[2, 2] == "X" ||
               mat[0, 2] == "X" && mat[1, 1] == "X" && mat[2, 0] == "X" ||
               mat[0, 0] == "X" && mat[1, 0] == "X" && mat[2, 0] == "X" ||
               mat[0, 1] == "X" && mat[1, 1] == "X" && mat[2, 1] == "X" ||
               mat[0, 2] == "X" && mat[1, 2] == "X" && mat[2, 2] == "X" ||

               mat[0, 0] == "0" && mat[0, 1] == "0" && mat[0, 2] == "0" ||
               mat[1, 0] == "0" && mat[1, 1] == "0" && mat[1, 2] == "0" ||
               mat[2, 0] == "0" && mat[2, 1] == "0" && mat[2, 2] == "0" ||
               mat[0, 0] == "0" && mat[1, 1] == "0" && mat[2, 2] == "0" ||
               mat[0, 2] == "0" && mat[1, 1] == "0" && mat[2, 0] == "0" ||
               mat[0, 0] == "0" && mat[1, 0] == "0" && mat[2, 0] == "0" ||
               mat[0, 1] == "0" && mat[1, 1] == "0" && mat[2, 1] == "0" ||
               mat[0, 2] == "0" && mat[1, 2] == "0" && mat[2, 2] == "0")
                //return 1;

                if (mat[0, 0] != " " && mat[1, 0] != " " && mat[2, 0] != " " &&
                    mat[0, 1] != " " && mat[1, 1] != " " && mat[2, 1] != " " &&
                    mat[0, 2] != " " && mat[1, 2] != " " && mat[2, 2] != " ") { }
                //return -1;

            //return 0;
        }
    }
}
