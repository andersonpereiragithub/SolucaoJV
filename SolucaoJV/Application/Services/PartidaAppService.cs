using SolucaoJV.UI.Views;
using SolucaoJV.Application.Interfaces;
using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.Services;
using System;

namespace SolucaoJV.Application.Services
{
    internal class PartidaAppService : IPartidaService
    {
        private TipoJogador _jogadorAtual;
        private readonly PartidaDomainService _partidaDomainService;
        private readonly Tabuleiro _tabuleiroUI;

        public PartidaAppService(Tabuleiro tabuleiro, PartidaDomainService partidaDomainService)
        {
           _jogadorAtual = TipoJogador.X;
           _tabuleiroUI = tabuleiro;
           _partidaDomainService = partidaDomainService;
        }

        public void IniciarPartida()
        {
            _tabuleiroUI.LimparTabuleiro();
        }
        public void MudarJogador()
        {
            if (_jogadorAtual == TipoJogador.X)
            {
                _jogadorAtual = TipoJogador.O;
            }
            else
            {
                _jogadorAtual = TipoJogador.X;
            }
        }

        public void ReiniciarPartida()
        {
            _tabuleiroUI.EscreverEm("                        ", 8, 15);
            _tabuleiroUI.EscreverEm("Deseja Reiniciar (s/n)? ", 10, 16);
            
            char resposta = char.Parse(Console.ReadLine());
            if (resposta.Equals('s'))
            {
                IniciarPartida();
            }

            Environment.Exit(0);    
            
        }
    }
}
