using SolucaoJV.Application.Services;
using SolucaoJV.UI.Controllers;
using System;

namespace SolucaoJV.Application.Interfaces
{
    public interface IPartidaAppService
    {
        void IniciarPartida();
        void MudarJogador();
        bool RegistrarJogada(int linha, int coluna);
        bool ReiniciarPartida();
    }
}
