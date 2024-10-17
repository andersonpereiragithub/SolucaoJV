using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.ValueObjects;
using System;

namespace SolucaoJV.Domain.Services
{
    internal class PartidaDomainService
    {
        private int Linha { get; set; } //TORNAR ESSA VARIÁVEL PRIVADA
        private int Coluna { get; set; } //TORNAR ESSA VARIÁVEL PRIVADA
        public string[,] Jogadas { get; private set; }
        public TipoJogador JogadorAtual { get; set; }
        public bool Terminada { get; set; }
        public int Turno { get; set; }

        public PartidaDomainService()
        {
            IniciarJogadas();
            JogadorAtual = TipoJogador.X;
            Terminada = false;
            Turno = 1;
        }

        public int ObterTurno()
        {
            return Turno;
        }

        private void IniciarJogadas()
        {
            Jogadas = new string[3, 3];
        }

        public string VerificarVitoria()
        {
            int v = CondicaoDeVitoria(Jogadas);

            if (v == 1)
            {
                Console.BackgroundColor = ConsoleColor.White;

                if (JogadorAtual.ToString() == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    string vencedor = JogadorAtual.ToString();
                    return vencedor;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    string vencedor = JogadorAtual.ToString();
                    return vencedor;
                }
            }
            else if (v == -1)
            {
                Terminada = true;
                return null;
            }
            return null;
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

        public bool PosicaoDisponivel(int linha, int coluna)
        {
            if (Jogadas[linha, coluna] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RegistrarJogada(char linha, int coluna)
        {
            Linha = linha - 'a';
            Coluna = coluna - 1;
        }


        public void MudarJogador()
        {
            if (JogadorAtual == TipoJogador.X)
            {
                JogadorAtual = TipoJogador.O;
            }
            else
            {
                JogadorAtual = TipoJogador.X;
                IncrementarTurno();
            }
        }

        public void IncrementarTurno()
        {
            Turno++;
        }

        public void LimparTabuleiro()
        {
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    Jogadas[linha, coluna] = null;
                }

            }
            JogadorAtual = TipoJogador.X;
            Terminada = false;
            Turno = 1;
        }
    }
}

