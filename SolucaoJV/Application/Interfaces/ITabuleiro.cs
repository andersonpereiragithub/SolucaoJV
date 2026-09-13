using SolucaoJV.Domain.Entities;

namespace SolucaoJV.Application.Interfaces
{
    internal interface ITabuleiro
    {
        void DesenharTabuleiroJogo();
        void ImprimirControladores(int turno, TipoJogador jogador);
        void ImprimeJogada(TipoJogador jogador, int linha, int coluna);
    }
}
