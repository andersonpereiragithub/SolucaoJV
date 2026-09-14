using SolucaoJV.Domain.Entities;

namespace SolucaoJV.Domain.Services
{
    internal class PartidaDomainService
    {
        private TipoJogador?[,] Jogadas { get; }
        public TipoJogador JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; }

        private const int TamanhoTabuleiro = 3;
        public PartidaDomainService()
        {
            Jogadas = new TipoJogador?[TamanhoTabuleiro, TamanhoTabuleiro];
            JogadorAtual = TipoJogador.X;
            Terminada = false;
            Turno = 1;
        }

        public ResultadoPartida DeterminarResultado(out TipoJogador? vencedor)
        {
            vencedor = null;

            if (VerificarVitoria(TipoJogador.X))
            {
                vencedor = TipoJogador.X;
            }

            else if (VerificarVitoria(TipoJogador.O))
            {
                vencedor = TipoJogador.O;
            }

            if (vencedor != null)
            {
                Terminada = true;
                return ResultadoPartida.Vitoria;
            }

            for (int linha = 0; linha < Jogadas.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < Jogadas.GetLength(1); coluna++)
                {
                    if (Jogadas[linha, coluna] == null)
                    {
                        return ResultadoPartida.Continua;
                    }
                }
            }

            Terminada = true;
            return ResultadoPartida.Empate;

            bool VerificarVitoria(TipoJogador jogador)
            {
                for (int i = 0; i < Jogadas.GetLength(0); i++)
                {
                    bool linhasIguais = (Jogadas[i, 0] == jogador && Jogadas[i, 1] == jogador && Jogadas[i, 2] == jogador);
                    bool colunasIguais = (Jogadas[0, i] == jogador && Jogadas[1, i] == jogador && Jogadas[2, i] == jogador);

                    if (linhasIguais || colunasIguais)
                    {
                        return true;
                    }
                }

                bool diagonalPrincipalIgual = (Jogadas[0, 0] == jogador && Jogadas[1, 1] == jogador && Jogadas[2, 2] == jogador);
                bool diagonalSecundariaIgual = (Jogadas[0, 2] == jogador && Jogadas[1, 1] == jogador && Jogadas[2, 0] == jogador);

                return diagonalPrincipalIgual || diagonalSecundariaIgual;
            }
        }

        private bool PosicaoDisponivel(int linha, int coluna)
        {
            return Jogadas[linha, coluna] == null;
        }

        public bool TentarRegistrarJogada(int linha, int coluna)
        {
            if (!PosicaoDisponivel(linha, coluna))
            {
                return false;
            }

            Jogadas[linha, coluna] = JogadorAtual;
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
                Turno++;
            }
        }

        public void ReiniciarEstadoPartida()
        {
            for (int linha = 0; linha < Jogadas.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < Jogadas.GetLength(1); coluna++)
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

