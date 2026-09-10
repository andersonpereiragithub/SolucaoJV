using SolucaoJV.Domain.Entities;

namespace SolucaoJV.Domain.Services
{
    internal class PartidaDomainService
    {
        private string[,] Jogadas { get; }
        public TipoJogador JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; }

        public PartidaDomainService()
        {
            Jogadas = new string[3, 3];
            JogadorAtual = TipoJogador.X;
            Terminada = false;
            Turno = 1;
        }

        public ResultadoPartida VerificarResultado(out TipoJogador? vencedor)
        {
               return CondicaoDeVitoria(out vencedor);
        }

        private ResultadoPartida CondicaoDeVitoria(out TipoJogador? vencedor)
        {
            vencedor = null;

            if (VerificarVitoria("X"))
            {
                vencedor = TipoJogador.X;
                Terminada = true;
                return ResultadoPartida.Vitoria;
            }

            if (VerificarVitoria("O"))
            {
                vencedor = TipoJogador.O;
                Terminada = true;
                return ResultadoPartida.Vitoria;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Jogadas[i, j] == null)
                    {
                        return ResultadoPartida.Continua;
                    }
                }
            }

            Terminada = true;
            return ResultadoPartida.Empate;

            bool VerificarVitoria(string jogador)
            {
                for (int i = 0; i < 3; i++)
                {
                    bool linhasIguais = (Jogadas[i, 0] == jogador && Jogadas[i, 1] == jogador && Jogadas[i, 2] == jogador);
                    bool colunasIguais = (Jogadas[0, i] == jogador && Jogadas[1, i] == jogador && Jogadas[2, i] == jogador);

                    if (linhasIguais || colunasIguais)
                    {
                        return true;
                    }
                }

                    bool diagonalPricipalIgual = (Jogadas[0, 0] == jogador && Jogadas[1, 1] == jogador && Jogadas[2, 2] == jogador);
                    bool diagonalSecundariaIgual = (Jogadas[0, 2] == jogador && Jogadas[1, 1] == jogador && Jogadas[2, 0] == jogador);
                
                return diagonalPricipalIgual || diagonalSecundariaIgual;
            }
        }

        private bool PosicaoDisponivel(int linha, int coluna)
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

        private void IncrementarTurno()
        {
            Turno++;
        }

        public void ReiniciarEstadoPartida()
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

