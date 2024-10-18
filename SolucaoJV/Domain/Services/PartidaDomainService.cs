using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.ValueObjects;
using System;

namespace SolucaoJV.Domain.Services
{
    internal class PartidaDomainService
    {
        const int VITORIA = 1;
        const int CONTINUA = 0;
        const int EMPATE = -1;

        private int Linha { get; set; }
        private int Coluna { get; set; }
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
            int resultadoPartida = CondicaoDeVitoria(Jogadas);

            if (resultadoPartida == VITORIA)
            {
                AlterarCorDeFundo(ConsoleColor.White);
                AlterarCorDeTextoPorJogador(JogadorAtual);

                return JogadorAtual.ToString();
            }
            else if (resultadoPartida == EMPATE)
            {
                Terminada = true;
            }

            return null;
        }

        private void AlterarCorDeTextoPorJogador(TipoJogador jogador)
        {
            if (jogador == TipoJogador.X)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
        }

        private void AlterarCorDeFundo(ConsoleColor cor)
        {
            Console.BackgroundColor = cor;
        }

        public int CondicaoDeVitoria(string[,] mat)
        {
            if (VerificarVitoria("X"))
            {
                Terminada = true;
                return VITORIA;
            }

            if (VerificarVitoria("O"))
            {
                Terminada = true;
                return VITORIA;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mat[i, j] == null)
                    {
                        return CONTINUA;
                    }
                }
            }

            Terminada = true;
            return EMPATE;

            bool VerificarVitoria(string jogador)
            {
                for (int i = 0; i < 3; i++)
                {
                    bool linhasIguais = (mat[i, 0] == jogador && mat[i, 1] == jogador && mat[i, 2] == jogador);
                    bool colunasIguais = (mat[0, i] == jogador && mat[1, i] == jogador && mat[2, i] == jogador);
                    bool diagonalPricipalIgual = (mat[0, 0] == jogador && mat[1, 1] == jogador && mat[2, 2] == jogador);
                    bool diagonalSecundariaIgual = (mat[0, 2] == jogador && mat[1, 1] == jogador && mat[2, 0] == jogador);

                    if (linhasIguais || colunasIguais || diagonalPricipalIgual || diagonalSecundariaIgual)
                    {
                        return true;
                    }
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

