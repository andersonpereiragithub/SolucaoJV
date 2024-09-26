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
                            partida.VefificarVitoria(tab);
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

        public void VefificarVitoria(Tabuleiro t)
        {
            int v = CondicaoDeVitoria(Jogadas);
            if (v == 1)
            {
                t.EscreverEm(Convert.ToString(JogadorAtual), 20, 15);
                
                Console.BackgroundColor = ConsoleColor.White;
                
                if (JogadorAtual == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                    t.EscreverEm("Venceu!!!", 14, 14);
                    ReiniciarPartida();
            }
            else if (v == -1)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Cyan;
                
                t.EscreverEm("Deu EMPATE!", 17, 15);
                ReiniciarPartida();
            }
                Console.ResetColor();
        }
        public int CondicaoDeVitoria(string[,] mat)
        {
            if (VerificarVitoria("X"))
            {
                Terminada = true;
                return 1;  // Vitória de "X"
            }

            if (VerificarVitoria("O"))
            {
                Terminada = true;
                return 1;  // Vitória de "O"
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mat[i, j] == null)
                    {
                        return 0;  // Jogo ainda em andamento
                    }
                }
            }

            return -1;
            
            bool VerificarVitoria(string jogador)
            {
                for (int i = 0; i < 3; i++)
                {
                    if ((mat[i, 0] == jogador && mat[i, 1] == jogador && mat[i, 2] == jogador) ||  // Linha
                        (mat[0, i] == jogador && mat[1, i] == jogador && mat[2, i] == jogador))   // Coluna
                    {
                        return true;
                    }
                }
                if ((mat[0, 0] == jogador && mat[1, 1] == jogador && mat[2, 2] == jogador) ||  // Diagonal principal
                    (mat[0, 2] == jogador && mat[1, 1] == jogador && mat[2, 0] == jogador))   // Diagonal secundária
                {
                    return true;
                }

                return false;
            }
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
