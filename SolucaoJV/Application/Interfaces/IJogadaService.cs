
namespace SolucaoJV.Application.Interfaces
{
    internal interface IJogadaService
    {
        (int linha, int coluna)? LerJogada();
        bool DesejaReiniciar();
    }
}
