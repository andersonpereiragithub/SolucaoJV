using SolucaoJV.Domain.Entities;
using System;

namespace SolucaoJV.Application.Interfaces
{
    internal interface IMensagemService
    {
        void ExibirVencedor(TipoJogador vencedor);
        public void ExibirEmpate();
        bool DesejaReiniciar();
        void ExibirPosicaoOcupada(int linha, int coluna);
        void LimparMensagemJogada();
    }
}
