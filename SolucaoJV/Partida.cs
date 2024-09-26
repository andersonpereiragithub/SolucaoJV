using System;
using View;

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
                Tabuleiro tab = new Tabuleiro();

                tab.ImprimirControladores(partida);

                p.LerJogada();

                while (!posicao)
                {
                    bool posicaoTabuleiroDisponivel = partida.Jogadas[p.Linha, p.Coluna] == null;
                    
                    if (posicaoTabuleiroDisponivel)
                    {
                        partida.Jogadas[p.Linha, p.Coluna] = Convert.ToString(partida.JogadorAtual);

                        tab.ImprimeJogadas(Convert.ToString(partida.JogadorAtual), p.Linha, p.Coluna);

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
            Tabuleiro t = new Tabuleiro();
            int v = CondicaoDeVitoria(Jogadas);
            if (v == 1)
            {
                t.EscreverEm(Convert.ToString(JogadorAtual), 20, 15);
                if (Convert.ToString(JogadorAtual) == "X")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    t.EscreverEm("Venceu!!!", 14, 14);
                    ReiniciarPartida();
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    t.EscreverEm("Venceu!!!", 14, 14);
                    ReiniciarPartida();
                    Console.ResetColor();
                }
            }
            else if (v == -1)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Cyan;
                t.EscreverEm("Deu EMPATE!", 17, 15);
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
            Tabuleiro t = new Tabuleiro();
            t.EscreverEm("                       ", 8, 15);
            t.EscreverEm("Deseja Reinciar (s/n)? ", 10, 16);
            
            char resp = char.Parse(Console.ReadLine());
            if (resp.Equals('s'))
                t.ImprimirTelaJogo();

            Environment.Exit(1);
        }
    }
}
