using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV.Application.Interfaces
{
    internal interface IPartidaService
    {
        void IniciarPartida(PartidaService partida);
        void MudarJogador(TipoJogador jogador);
        void RegistrarJogada(char linha, int coluna);
        int VerificarCondicaoDeVitoria();
        void ReniciarPartida();
        bool JogoTerminou();

    }
}
