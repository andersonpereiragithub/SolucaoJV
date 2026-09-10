using SolucaoJV.Domain.Entities;

namespace SolucaoJV.Application.Interfaces
{
    internal interface IMensagemService
    {
        void ExibirVencedor(TipoJogador vencedor);
        public void ExibirEmpate();
        void ExibirMensagemReinicio();
        void ExibirPosicaoOcupada(int linha, int coluna);
        void LimparMensagemJogada();
    }
}
