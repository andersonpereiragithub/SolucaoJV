using SolucaoJV.UI.Views;
using SolucaoJV.Domain.Entities;
using System;

namespace SolucaoJV.Application.Services
{
    internal class PartidaService : IPartidaService
    {
        private TipoJogador _jogadorAtual;
        private readonly Tabuleiro _tabuleiroUI;

        public PartidaService(Tabuleiro tabuleiro)
        {
           _jogadorAtual = TipoJogador.X;
           _tabuleiroUI = tabuleiro;
        }

        public void InciarPartida()
        {
            _tabuleiroUI.LimparTabuleiro();
        }

        public bool JogoTerminou()
        {
            int VitoriaOuEmpate = CondicaoDeVitoria();
        }
    }
}
