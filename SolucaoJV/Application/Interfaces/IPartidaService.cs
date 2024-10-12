using SolucaoJV.Application.Services;
using SolucaoJV.UI.Controllers;
using System;

namespace SolucaoJV.Application.Interfaces
{
    public interface IPartidaService
    {
        void IniciarPartida();
        void MudarJogador();
        void RegistrarJogada(int linha, int coluna);
        void ReiniciarPartida();
    }
}
