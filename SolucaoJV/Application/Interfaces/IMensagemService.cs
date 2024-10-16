using System;

namespace SolucaoJV.Application.Interfaces
{
    internal interface IMensagemService
    {
        void ExibirVencedor(string vencedor);
        public void ExibirEmpate();
        void MensagemSeDesejaReiniciar();
    }
}
