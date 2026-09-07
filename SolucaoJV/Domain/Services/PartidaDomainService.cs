using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.ValueObjects;

namespace SolucaoJV.Domain.Services
{
    internal class PartidaDomainService
    {
        const int VITORIA = 1;
        const int CONTINUA = 0;
        const int EMPATE = -1;

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
            int resultadoPartida = CondicaoDeVitoria(Jogadas, out string vencedor);

            if (resultadoPartida == VITORIA)
            {
                return vencedor;
            }
            
            return null;
        }

        public int CondicaoDeVitoria(string[,] mat, out string vencedor)
        {
            vencedor = null;

            if (VerificarVitoria("X"))
            {
                vencedor = "X";
                Terminada = true;
                return VITORIA;
            }

            if (VerificarVitoria("O"))
            {
                vencedor = "O";
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

                    if (linhasIguais || colunasIguais)
                    {
                        return true;
                    }
                }

                    bool diagonalPricipalIgual = (mat[0, 0] == jogador && mat[1, 1] == jogador && mat[2, 2] == jogador);
                    bool diagonalSecundariaIgual = (mat[0, 2] == jogador && mat[1, 1] == jogador && mat[2, 0] == jogador);
                
                return diagonalPricipalIgual || diagonalSecundariaIgual;
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

        public bool TentarRegistrarJogada(int linha, int coluna)
        {
            if (!PosicaoDisponivel(linha, coluna))
            {
                return false;
            }

            Jogadas[linha, coluna] = JogadorAtual.ToString();
            return true;
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

