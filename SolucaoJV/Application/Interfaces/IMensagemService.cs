using System;

namespace SolucaoJV.Application.Interfaces
{
    internal interface IMensagemService
    {
        void ExibirVencedor(string vencedor);
        string PerguntarSeDesejaReiniciar();
    }
}
