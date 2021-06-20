using System;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV
{
    class Partida
    {
        public int QtePartida { get; set; }
        public int Turno { get; set; }
        public TipoJogador JogadorAtual { get; private set; }
        public bool Terminada { get; set; }
        public string[,] Jogadas { get; set; }

        public Partida()
        {
            QtePartida = 0;
            Turno = 1;
            JogadorAtual = TipoJogador.X;
            Terminada = false;
            Jogadas = new string[3, 3];
        }
        public static void IniciarPartida()
        {
            Partida partida = new Partida();

            while (!partida.Terminada)
            {
                bool posicao = false;
                Posicao p = new Posicao();


                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Tela.EscreverEm("Turno: ", 0, 13);
                Tela.EscreverEm(Convert.ToString(partida.Turno), 8, 13);
                Tela.EscreverEm("Jogador [", 0, 14);
                Tela.EscreverEm("]", 12, 14);
                Tela.EscreverEm(Convert.ToString(partida.JogadorAtual), 10, 14);
                Console.ResetColor();
                
                p.LerJogada();

                while (!posicao)
                {
                    if (partida.Jogadas[p.Linha, p.Coluna] == null)
                    {
                        partida.Jogadas[p.Linha, p.Coluna] = Convert.ToString(partida.JogadorAtual);
                        Tela.SetJogadas(Convert.ToString(partida.JogadorAtual), p.Linha, p.Coluna);

                        if (partida.Turno > 2)
                        {
                            partida.VefificarVitoria();
                        }
                        posicao = true;
                    }
                    else
                    {
                        p.JogadaInvalida();
                        p.LerJogada();
                    }
                }
                partida.MudarJogador();
            }
        }
        public void IncrementarTurno()
        {
            Turno++;
        }
        public void MudarJogador()
        {
            if (JogadorAtual == TipoJogador.X)
                JogadorAtual = TipoJogador.O;
            else
            {
                IncrementarTurno();
                JogadorAtual = TipoJogador.X;
            }
        }

        public void VefificarVitoria()
        {
            int v = CondicaoDeVitoria(Jogadas);
            if (v == 1)
            {
                Tela.EscreverEm(Convert.ToString(JogadorAtual), 20, 15);
                if (Convert.ToString(JogadorAtual) == "X")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Tela.EscreverEm("Venceu!!!", 14, 14);
                    ReiniciarPartida();
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Tela.EscreverEm("Venceu!!!", 14, 14);
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
            Tela.EscreverEm("                       ", 8, 15);
            Tela.EscreverEm("Deseja Reinciar (s/n)? ", 10, 16);
            
            char resp = char.Parse(Console.ReadLine());
            if (resp.Equals('s'))
                Tela.ViewTela();

            Environment.Exit(1);
        }
    }
}
